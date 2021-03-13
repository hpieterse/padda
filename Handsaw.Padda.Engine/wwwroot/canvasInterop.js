export const setup = (canvas) => {
    // create a click event to pre-load
    // all the event handlers to prevent
    // performance issues on first real click

    var clickEvent = new MouseEvent('click', {
        view: window,
        bubbles: true,
        cancelable: true
    });
    var cancelled = canvas.dispatchEvent(clickEvent);
}

export const setSize = (canvas, width, height) => {
    try {
        canvas.width = width;
        canvas.height = height;

        // get bounding box
        const boundingBox = canvas.getBoundingClientRect()

        return `${boundingBox.x},${boundingBox.y}`

    } catch (error) {
        console.error(error);
    }
}

export const setSizeUnmarshalled = (params) => {
    var width = Blazor.platform.readFloatField(params, 0);
    var height = Blazor.platform.readFloatField(params, 4);
    var canvasId = Blazor.platform.readStringField(params, 8);
    var canvas = document.getElementById(canvasId);

    var result = setSize(canvas, width, height);

    return BINDING.js_to_mono_obj(result);
}

const images = {};

export const loadImage = async(dotnetService, src, imageId) => {
    try {
        if (images[imageId] != null) {
            await dotnetService.invokeMethodAsync("OnImageLoaded", imageId);
        }

        var image = new Image();
        image.onload = async() => {
            images[imageId] = image;
            await dotnetService.invokeMethodAsync("OnImageLoaded", imageId);
        };
        image.src = src;

    } catch (error) {
        console.error(error);
    }
}

export const unloadImage = async(imageId) => {
    images[imageId] = undefined;
}


export const clear = (canvas) => {
    try {
        var context = canvas.getContext("2d");
        context.clearRect(0, 0, canvas.width, canvas.height);
    } catch (error) {
        console.error(error);
    }
}

export const clearUnmarshalled = (params) => {
    const canvasId = Blazor.platform.readStringField(params, 0);
    const canvas = document.getElementById(canvasId);
    clear(canvas);
    return BINDING.js_to_mono_obj("");
}

export const draw = (canvas, operations) => {
    try {
        var context = canvas.getContext("2d");
        operations.forEach((operation) => {
            switch (operation.drawOperation) {
                case 0:
                    drawRect(
                        context,
                        operation.x,
                        operation.y,
                        operation.width,
                        operation.height,
                        operation.color);
                    break;
                case 1:
                    drawArch(
                        context,
                        operation.x,
                        operation.y,
                        operation.startAngle,
                        operation.endAngle,
                        operation.clockwise,
                        operation.color);
                    break;
                case 2:
                    drawLine(
                        context,
                        operation.x,
                        operation.y,
                        operation.width,
                        operation.height,
                        operation.radius,
                        operation.color);
                    break;
                case 3:
                    drawText(
                        context,
                        operation.x,
                        operation.y,
                        operation.font,
                        operation.content,
                        operation.color);
                    break;
                case 4:
                    const image = images[operation.content];

                    drawImage(context,
                        image,
                        operation.x2,
                        operation.y2,
                        operation.width2,
                        operation.height2,
                        operation.x,
                        operation.y,
                        operation.width,
                        operation.height);
                    break;
                default:
                    console.error(`Unsupported draw operation ${operation.drawOperation}`);
            }
        });
    } catch (error) {
        console.error(error);
    }
}

export const drawUnmarshalled = (params, array) => {
    const operations = [];

    try {
        const arrayLength = Blazor.platform.getArrayLength(array);

        for (let i = 0; i < arrayLength; i++) {

            const ptr = Blazor.platform.getArrayEntryPtr(array, i, 324);

            const drawOperation = Blazor.platform.readInt32Field(ptr, 0);
            const x = Blazor.platform.readFloatField(ptr, 4);
            const y = Blazor.platform.readFloatField(ptr, 8);
            const color = Blazor.platform.readStringField(ptr, 12);
            const content = Blazor.platform.readStringField(ptr, 24);
            const font = Blazor.platform.readStringField(ptr, 156);
            const width = Blazor.platform.readFloatField(ptr, 280);
            const height = Blazor.platform.readFloatField(ptr, 284);
            const radius = Blazor.platform.readFloatField(ptr, 288);
            const startAngle = Blazor.platform.readFloatField(ptr, 296);
            const endAngle = Blazor.platform.readFloatField(ptr, 300);
            const clockwise = Blazor.platform.readInt32Field(ptr, 304) === 1;
            const x2 = Blazor.platform.readFloatField(ptr, 308);
            const y2 = Blazor.platform.readFloatField(ptr, 312);
            const width2 = Blazor.platform.readFloatField(ptr, 316);
            const height2 = Blazor.platform.readFloatField(ptr, 320);

            operations.push({
                drawOperation,
                x,
                y,
                color,
                content,
                font,
                width,
                height,
                radius,
                startAngle,
                endAngle,
                clockwise,
                x2,
                y2,
                width2,
                height2,
            });
        }

    } catch (error) {
        console.error(error);
    }

    const canvasId = Blazor.platform.readStringField(params, 0);
    const canvas = document.getElementById(canvasId);

    draw(canvas, operations);

    return BINDING.js_to_mono_obj("");
}

const drawArch = (context, x, y, r, sAngle, eAngle, clockwise, color) => {
    context.beginPath();
    context.arc(x, y, r, sAngle, eAngle, !clockwise);
    context.fillStyle = color;
    context.fill();
}

const drawRect = (context, x, y, width, height, color) => {
    context.beginPath();
    context.rect(x, y, width, height);
    context.fillStyle = color;
    context.fill();
}

const drawLine = (context, startX, startY, endX, endY, width, color) => {
    context.beginPath();
    context.beginPath();
    context.moveTo(startX, startY);
    context.lineTo(endX, endY);
    context.lineWidth = width;
    context.strokeStyle = color;
    context.stroke();
}

const drawText = (context, x, y, font, text, color) => {
    context.font = font;
    context.fillStyle = color;
    context.fillText(text, x, y);
}

const drawImage = (context, image, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight) => {
    context.imageSmoothingEnabled = false;
    context.drawImage(image, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);
}