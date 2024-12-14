﻿using System;
using System.Drawing;

namespace LTWINDOW_
{
    public class Mon
    {
        public string MaLoaiMon { get; set; }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        public byte[] Image { get; set; }

        // Constructor đầy đủ
        public Mon(string maLoaiMon, string maMon, string tenMon, double gia, int soLuong, byte[] image)
        {
            MaLoaiMon = maLoaiMon;
            MaMon = maMon;
            TenMon = tenMon;
            Gia = gia;
            SoLuong = soLuong;
            Image = image;
        }

        // Constructor mặc định
        public Mon() { }

        // Chuyển byte[] sang Image
        public Image ConvertBytesToImage()
        {
            if (Image == null || Image.Length == 0)
                return null;

            using (var ms = new System.IO.MemoryStream(Image))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        // Chuyển Image sang byte[]
        public static byte[] ConvertImageToBytes(Image img)
        {
            if (img == null)
                return null;

            using (var ms = new System.IO.MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        // Kiểm tra tính hợp lệ của dữ liệu
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(MaMon) &&
                   !string.IsNullOrWhiteSpace(TenMon) &&
                   Gia > 0 &&
                   SoLuong >= 0;
        }

        // Ghi đè ToString
        public override string ToString()
        {
            return $"{TenMon} - Giá: {Gia:N0} đ - Số lượng: {SoLuong}";
        }
    }
}