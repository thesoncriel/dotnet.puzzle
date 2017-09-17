using System;
using System.IO;
using System.Drawing;

namespace ImageConverter
{
	class ImageConverter
	{
		private string subDirectory = "";
		
        /// <summary>
        /// 바꿀 이미지가 하위 디렉토리에 단체로 들어있을 경우 미리 이 메서드를 실행 시키십시오. 이미지 파일 참조시 하위 디렉토리까지 모두 고려할 계획이라면 굳이 안해도 무방~
        /// </summary>
        /// <param name="sub">string 형태의 하위 디렉토리명</param>
		public void setSubDirectory(string sub)
		{
			this.subDirectory = sub;
		}
		/// <summary>
		/// 이미지 크기를 재설정 합니다.
		/// </summary>
		/// <param name="image">원하는 이미지</param>
		/// <param name="width">재설정 할 가로 크기</param>
		/// <param name="height">재설정 할 세로 크기</param>
        /// <returns>Image 형태의 변경된 그림</returns>
		public Image ResizeImage(Image image, int width, int height)
		{
            return ResizeImage_common(image, width, height);
		}
        /// <summary>
        /// 이미지 크기를 재설정 합니다.
        /// </summary>
        /// <param name="image">원하는 이미지</param>
        /// <param name="percent">재설정 할 크기 - 백분율 기준</param>
        /// <returns>Image 형태의 변경된 그림</returns>
        public Image ResizeImage(Image image, int percent)
        {
            int resizeWidth = (int)(image.Width * percent/100);
            int resizeHeight = (int)(image.Height * percent/100);
            return ResizeImage_common(image, resizeWidth, resizeHeight);
        }
		/// <summary>
		/// 이미지 크기를 재설정 합니다. 외부 이미지의 경로를 참조합니다.
		/// </summary>
		/// <param name="imagePath">원하는 이미지의 파일명</param>
		/// <param name="width">재설정 할 가로 크기</param>
		/// <param name="height">재설정 할 세로 크기</param>
		/// <returns>Image 형태의 변경된 그림</returns>
		public Image ResizeImage(string imagePath, int width, int height)
		{
            Image image = null;
            try
            {
                image = Image.FromFile(Environment.CurrentDirectory + this.subDirectory + imagePath);
            }
            catch
            {
                image = Image.FromFile(this.subDirectory + imagePath);
            }
            return ResizeImage_common(image, width, height);
		}
        /// <summary>
        /// 이미지 크기를 재설정 합니다. 외부 이미지의 경로를 참조합니다.
        /// </summary>
        /// <param name="imagePath">원하는 이미지의 파일명</param>
        /// <param name="percent">재설정 할 크기 - 백분율 기준</param>
        /// <returns>Image 형태의 변경된 그림</returns>
        public Image ResizeImage(string imagePath, int percent)
        {
            Image image = null;
            try
            {
                image = Image.FromFile(Environment.CurrentDirectory + this.subDirectory + imagePath);
            }
            catch
            {
                image = Image.FromFile(this.subDirectory + imagePath);
            }
            int resizeWidth = (int)(image.Width * percent / 100);
            int resizeHeight = (int)(image.Height * percent / 100);
            return ResizeImage_common(image, resizeWidth, resizeHeight);
        }

        private Image ResizeImage_common(Image image, int width, int height)
        {
            Bitmap imgResize = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics gp = Graphics.FromImage(imgResize);
            gp.DrawImage(image, 0, 0, width, height);
            gp.Dispose();
            return imgResize;
        }

        //
        //
        //
        /// <summary>
        /// 이미지의 특정 부분을 잘라냅니다.
        /// </summary>
        /// <param name="image">잘라낼 원본 이미지</param>
        /// <param name="x">원본 이미지상의 가로 좌표</param>
        /// <param name="y">원본 이미지상의 세로 좌표</param>
        /// <param name="width">잘라낼 가로 길이</param>
        /// <param name="height">잘라낼 세로 길이</param>
        /// <returns>Image - 잘라낸 이미지</returns>
        public Image CropImage(Image image, int x, int y, int width, int height)
        {
            Bitmap imgCrop = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics gp = Graphics.FromImage(imgCrop);
            gp.DrawImage(image, new Rectangle(0,0,width,height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
            gp.Dispose();
            return imgCrop;
        }
        /// <summary>
        /// 지정한 이미지를 파일로 저장 합니다.
        /// </summary>
        /// <param name="image">이미지 데이터</param>
        /// <param name="filePath">파일 경로</param>
        public void Save(Image image, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Close();
        }
	}
}