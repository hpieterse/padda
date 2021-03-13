using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Handsaw.Padda.Engine.Services
{
  /// <summary>
  /// Service to play audio files
  /// </summary>
  public interface IAudioService
  {
    /// <summary>
    /// Load audio files
    /// </summary>
    /// <param name="src">The path to the audio file</param>
    /// <returns>The ids of the audio file loaded</returns>
    Task<IEnumerable<Guid>> LoadAudio(params string[] src);

    /// <summary>
    /// Unloads an audio file
    /// </summary>
    /// <param name="id">Id of the audio file</param>
    /// <returns></returns>
    Task UnloadAudio(Guid id);

    /// <summary>
    /// Play a loaded audio file
    /// </summary>
    /// <param name="id"></param>
    /// <param name="loop">Whether the audio should be looped</param>
    /// <param name="startOffset">seconds from the start of the file to start
    /// the playback</param>
    /// <param name="playLength">The length of the track to play. If not specified
    /// the track will play to the end</param>
    Task PlayAudio(Guid id, bool loop= false, float startOffset = 0, float? playLength  = null);

    /// <summary>
    /// Stop playing an audio file
    /// </summary>
    /// <param name="id"></param>
    Task StopAudio(Guid id);

  }
}
