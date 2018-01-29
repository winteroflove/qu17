using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.IO;
using System.Drawing.Imaging;

public partial class _random : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
        string str_ValidateCode = GetRandomNumberString(4);
        //  用于验证的Session
        Session["ValidateCode"] = str_ValidateCode;
        CreateImage(str_ValidateCode);
    }

    public string GetRandomNumberString(int int_NumberLength)
    {
        string str_Number = string.Empty;
        Random theRandomNumber = new Random();

        for (int int_index = 0; int_index < int_NumberLength; int_index++)
            str_Number += theRandomNumber.Next(10).ToString();

        return str_Number;
    }
    //生成随机颜色
    public Color GetRandomColor()
    {
        Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
        //  对于C#的随机数，没什么好说的
        System.Threading.Thread.Sleep(RandomNum_First.Next(50));
        Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);

        //  为了在白色背景上显示，尽量生成深色
        int int_Red = RandomNum_First.Next(0,256);
        int int_Green = RandomNum_Sencond.Next(0,120);
        int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
        int_Blue = (int_Blue > 255) ? 255 : int_Blue;

        return Color.FromArgb(int_Red, int_Green, int_Blue);
    }
    //根据验证字符串生成最终图象
    public void CreateImage(string str_ValidateCode)
    {
        int int_ImageWidth = str_ValidateCode.Length * 18;
        Random newRandom = new Random();
        //  图高24px
        Bitmap theBitmap = new Bitmap(int_ImageWidth, 24);
        Graphics theGraphics = Graphics.FromImage(theBitmap);
        //  白色背景
        theGraphics.Clear(Color.AliceBlue);
        //  灰色边框
        theGraphics.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, int_ImageWidth - 1, 23);

        //  10pt的字体
        Font theFont = new Font("Arial", 14);

        for (int int_index = 0; int_index < str_ValidateCode.Length; int_index++)
        {
            string str_char = str_ValidateCode.Substring(int_index, 1);
            Brush newBrush = new SolidBrush(GetRandomColor());
            Point thePos = new Point(int_index * 13 + 1 + newRandom.Next(3), 1 + newRandom.Next(3));
            theGraphics.DrawString(str_char, theFont, newBrush, thePos);
        }

        //  将生成的图片发回客户端
        MemoryStream ms = new MemoryStream();
        theBitmap.Save(ms, ImageFormat.Png);

        Response.ClearContent(); //需要输出图象信息 要修改HTTP头 
        Response.ContentType = "image/Png";
        Response.BinaryWrite(ms.ToArray());
        theGraphics.Dispose();
        theBitmap.Dispose();
        Response.End();
    }
}
