using System;
using System.Collections.Generic;
using System.Text;

//QRコード（2次元バーコード）を生成の参照
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
////https://github.com/micjahn/ZXing.Net
//using ZXing;
//using ZXing.QrCode;
using ThoughtWorks.QRCode.Codec;

public class CreateQRCode
{

    /// <summary>
    /// QRコードを生成する。
    /// </summary>
    /// <param name="qrContent"></param>
    /// <param name="qrScale"></param>
    /// <param name="qrVersion"></param>
    /// <returns></returns>
    public static byte[] ReturnByteArray(string qrContent, int? qrScale, int? qrVersion)
    {
        //QrCodeEncodingOptions options = new QrCodeEncodingOptions
        //{
        //    //禁用ECI编码段: use UTF-8 encoding and the ECI segment is omitted
        //    DisableECI = true,
        //    //设置内容编码
        //    CharacterSet = "UTF-8",
        //    //设置二维码的宽度
        //    Width = picWidth ?? 100,
        //    //设置二维码的高度
        //    Height = picHeight ?? 100,
        //    //设置二维码间隙
        //    Margin = 0,
        //    //设置二维码容错等级
        //    ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.L,
        //    //设置编码版本
        //    QrVersion = 4,
        //    //底部显示内容
        //    PureBarcode = false
        //};

        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
        //ALPHA_NUMERIC,BYTE,NUMERIC
        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
        //QRCode大小（増幅の割合）x N
        qrCodeEncoder.QRCodeScale = qrScale ?? 1;
        //文字の容量[0-40] 0：自動
        qrCodeEncoder.QRCodeVersion = qrVersion ?? 6;
        //QRコード密度 L/M/Q/H(小→大)
        qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;

        Bitmap image = qrCodeEncoder.Encode(qrContent);

        return ImageToBytes(image);
    }

    /// <summary>
    /// Convert Image to Byte[]
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public static byte[] ImageToBytes(Bitmap image)
    {
        ImageFormat format = image.RawFormat;
        using (MemoryStream ms = new MemoryStream())
        {
            switch (format.ToString())
            {
                case "ImageFormat.Jpeg":
                    image.Save(ms, ImageFormat.Jpeg);
                    break;
                case "ImageFormat.Png":
                    image.Save(ms, ImageFormat.Png);
                    break;
                case "ImageFormat.Bmp":
                    image.Save(ms, ImageFormat.Bmp);
                    break;
                case "ImageFormat.Gif":
                    image.Save(ms, ImageFormat.Gif);
                    break;
                case "ImageFormat.Icon":
                    image.Save(ms, ImageFormat.Icon);
                    break;
                default:
                    image.Save(ms, ImageFormat.Jpeg);
                    break;
            }
            byte[] buffer = new byte[ms.Length];
            ms.Seek(0, SeekOrigin.Begin);
            ms.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }

}

