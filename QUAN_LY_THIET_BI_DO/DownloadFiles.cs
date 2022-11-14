using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;

namespace QUAN_LY_THIET_BI_DO
{
    internal static class DownloadFiles
    {
        public static void DownloadFile()
        {
            using (var ftp = new FtpClient("172.28.10.17", "u36286", "trangpt"))
            {
                ftp.Connect();

                // download a file and ensure the local directory is created
                ftp.DownloadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md");

                // download a file and ensure the local directory is created, verify the file after download
                ftp.DownloadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpLocalExists.Overwrite, FtpVerify.Retry);

            }
        }
        public static void DownloadFile(string localPath, string remotePath)
        {

            using (var ftp = new FtpClient(Constant.FTP_ADDRESS, Constant.FTP_USER, Constant.FTP_PASS))
            {
                ftp.Connect();
                // download a file and ensure the local directory is created, verify the file after download
                ftp.DownloadFile(localPath, remotePath, FtpLocalExists.Overwrite, FtpVerify.Retry);

            }
        }

        public static async Task DownloadFileAsync()
        {
            var token = new CancellationToken();
            using (var ftp = new FtpClient("127.0.0.1", "ftptest", "ftptest"))
            {
                await ftp.ConnectAsync(token);

                // download a file and ensure the local directory is created
                await ftp.DownloadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md");

                // download a file and ensure the local directory is created, verify the file after download
                await ftp.DownloadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpLocalExists.Overwrite, FtpVerify.Retry);

            }
        }
        public static async Task DownloadFileAsync(string localPath, string remotePath)
        {
            var token = new CancellationToken();
            using (var ftp = new FtpClient(Constant.FTP_ADDRESS, Constant.FTP_USER, Constant.FTP_PASS))
            {
                await ftp.ConnectAsync(token);

                // download a file and ensure the local directory is created, verify the file after download
                await ftp.DownloadFileAsync(localPath, remotePath, FtpLocalExists.Overwrite, FtpVerify.Retry);

            }
        }
    }
}
