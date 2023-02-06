using Aaru.CommonTypes.Enums;

namespace Aaru.CommonTypes.Interfaces;

/// <inheritdoc cref="IWritableImage" />
/// <summary>Abstract class to implement flux writing plugins.</summary>
public interface IWritableFluxImage : IFluxImage, IWritableImage
{
    /// <summary>
    /// Writes a flux capture.
    /// </summary>
    /// <param name="resolution">The capture's resolution (sample rate) in picoseconds</param>
    /// <param name="index">Flux representation of the index signal</param>
    /// <param name="data">Flux representation of the data signal</param>
    /// <param name="head">Physical head (0-based)</param>
    /// <param name="track">Physical track (position of the heads over the floppy media, 0-based)</param>
    /// <param name="subTrack">Physical sub-step of track (e.g. half-track)</param>
    /// <param name="captureIndex">Which capture slot to write to. See also <see cref="IFluxImage.CapturesLength" /></param>
    /// <returns>Error number</returns>
    ErrorNumber WriteFluxCapture(ulong resolution, byte[] index, byte[] data, uint head, ushort track, byte subTrack,
                                 uint captureIndex);
}