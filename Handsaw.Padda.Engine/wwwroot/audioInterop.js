const AudioContextClass = window.AudioContext || window.webkitAudioContext;
const audioContext = new AudioContextClass();

const audioFiles = {};
const audioSources = {};

const decodeAudioData = (arrayBuffer) => {
    return new Promise((resolve, reject) => {
        audioContext.decodeAudioData(arrayBuffer,
            resolve, reject);
    });
}

export const loadAudio = async(src, audioId) => {
    try {
        if (audioFiles[audioId] != null) {
            return;
        }

        const response = await fetch(src);
        const arrayBuffer = await response.arrayBuffer();
        const audioBuffer = await decodeAudioData(arrayBuffer);
        audioFiles[audioId] = audioBuffer;

    } catch (error) {
        console.error(error);
    }
}

export const unloadAudio = async(audioId) => {
    audioFiles[audioId] = undefined;
}

export const playAudio = (audioId, loop, startOffset, playLength) => {
    // check if context is in suspended state (autoplay policy)
    if (audioContext.state === 'suspended') {
        audioContext.resume();
    }

    const trackSource = audioContext.createBufferSource();
    audioSources[audioId] = trackSource;
    trackSource.buffer = audioFiles[audioId];
    trackSource.connect(audioContext.destination)
    trackSource.loop = loop;
    if (startOffset == 0) {
        trackSource.start();
        startOffset = audioContext.currentTime;
    } else if (playLength == null) {
        trackSource.start(0, startOffset);
    } else {
        trackSource.start(0, startOffset, playLength);
    }
}

export const stopAudio = (audioId) => {
    const trackSource = audioSources[audioId];
    if (trackSource != null) {
        trackSource.disconnect();
        trackSource.stop(0);
        audioSources[audioId] = undefined;
    }
}