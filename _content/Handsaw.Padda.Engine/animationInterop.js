export const startAnimationLoop = async (dotnetService) => {
  await animationLoop(dotnetService);
}

const animationLoop = async (dotnetService) => {
  if (dotnetService != null) {
    await dotnetService.invokeMethodAsync("NewFrame");
  }

  window.requestAnimationFrame(() => { animationLoop(dotnetService); });
}
