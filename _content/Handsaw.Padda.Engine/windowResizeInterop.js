export function startListener(dotnetService) {
    window.onresize = () => {
        sendSizeChangedEvent(dotnetService);
    };
    sendSizeChangedEvent(dotnetService);
    return 0;
}

const sendSizeChangedEvent = (dotnetService) => {
    if (dotnetService != null) {
        dotnetService.invokeMethodAsync("OnSizeChanged", window.innerWidth, window.innerHeight);
    }
}