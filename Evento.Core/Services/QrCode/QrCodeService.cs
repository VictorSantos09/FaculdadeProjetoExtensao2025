using QRCoder;

namespace Evento.Core.Services.QrCode;
internal class QrCodeService
{
    private const int PIXELS = 50;
    public static string GenerateBase64(string content, int pixels = PIXELS)
    {
        using QRCodeGenerator qrGenerator = new();
        using QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        using Base64QRCode qrCode = new(qrCodeData);
        return qrCode.GetGraphic(pixels);
    }

    public static byte[] GeneratePNG(string content, int pixels = PIXELS)
    {
        using QRCodeGenerator qrGenerator = new();
        using QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        using PngByteQRCode qrCode = new(qrCodeData);
        return qrCode.GetGraphic(pixels);
    }
}
