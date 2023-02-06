using Aaru.CommonTypes.Enums;

namespace Aaru.CommonTypes.Interfaces;

/// <inheritdoc />
/// <summary>Abstract class to implement flux reading plugins.</summary>
public interface IFluxImage : IBaseImage
{
    /// <summary>
    ///     An image may have more than one capture for a specific head/track/sub-track combination. This returns
    ///     the amount of captures in the image for the specified head/track/sub-track combination.
    /// </summary>
    /// <returns>The number of captures</returns>
    /// <param name="head">Physical head (0-based)</param>
    /// <param name="track">Physical track (position of the heads over the floppy media, 0-based)</param>
    /// <param name="subTrack">Physical sub-step of track (e.g. half-track)</param>
    uint CapturesLength(uint head, ushort track, byte subTrack);

    /// <summary>Reads the resolution (sample rate) of a flux capture in picoseconds</summary>
    /// <returns>The resolution of a capture in picoseconds</returns>
    /// <param name="head">Physical head (0-based)</param>
    /// <param name="track">Physical track (position of the heads over the floppy media, 0-based)</param>
    /// <param name="subTrack">Physical sub-step of track (e.g. half-track)</param>
    /// <param name="captureIndex">Which capture to read. See also <see cref="CapturesLength" /></param>
    ulong ReadFluxResolution(uint head, ushort track, byte subTrack, uint captureIndex);

    /// <summary>Reads the entire flux capture with index and data streams, as well as its resolution</summary>
    /// <returns>Error number</returns>
    /// <param name="head">Physical head (0-based)</param>
    /// <param name="track">Physical track (position of the heads over the floppy media, 0-based)</param>
    /// <param name="subTrack">Physical sub-step of track (e.g. half-track)</param>
    /// <param name="captureIndex">Which capture to read. See also <see cref="CapturesLength" /></param>
    /// <param name="resolution">The capture's resolution (sample rate) in picoseconds</param>
    /// <param name="indexBuffer">Buffer to store the index stream in</param>
    /// <param name="dataBuffer">Buffer to store the data stream in</param>
    ErrorNumber ReadFluxCapture(uint head, ushort track, byte subTrack, uint captureIndex, out ulong resolution,
                                out byte[] indexBuffer, out byte[] dataBuffer);

    /// <summary>Reads a capture's index stream</summary>
    /// <returns>Error number</returns>
    /// <param name="head">Physical head (0-based)</param>
    /// <param name="track">Physical track (position of the heads over the floppy media, 0-based)</param>
    /// <param name="subTrack">Physical sub-step of track (e.g. half-track)</param>
    /// <param name="captureIndex">Which capture to read. See also <see cref="CapturesLength" /></param>
    /// <param name="buffer">Buffer to store the data in</param>
    ErrorNumber ReadFluxIndexCapture(uint head, ushort track, byte subTrack, uint captureIndex, out byte[] buffer);

    /// <summary>Reads a capture's data stream</summary>
    /// <returns>Error number</returns>
    /// <param name="head">Physical head (0-based)</param>
    /// <param name="track">Physical track (position of the heads over the floppy media, 0-based)</param>
    /// <param name="subTrack">Physical sub-step of track (e.g. half-track)</param>
    /// <param name="captureIndex">Which capture to read. See also <see cref="CapturesLength" /></param>
    /// <param name="buffer">Buffer to store the data in</param>
    ErrorNumber ReadFluxDataCapture(uint head, ushort track, byte subTrack, uint captureIndex, out byte[] buffer);
}