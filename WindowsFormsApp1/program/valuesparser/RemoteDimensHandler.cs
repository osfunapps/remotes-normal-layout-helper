using System;
using System.Windows.Forms;
using System.Xml;

namespace LayoutProject.program
{
    internal class RemoteDimensHandler
    {
        internal void SetRemoteDimens(XmlDocument xmlDocument, PictureBox remotePicFrame)
        {

            var layoutTag = xmlDocument.GetElementsByTagName(XMLPreparer.TAG_LAYOUT)[0];
            if (layoutTag.Attributes[XMLPreparer.ATT_HEIGHT] != null)
                return;
            XmlAttribute heightAtt = xmlDocument.CreateAttribute(XMLPreparer.ATT_HEIGHT);
            XmlAttribute widthAtt = xmlDocument.CreateAttribute(XMLPreparer.ATT_WIDTH);
            XmlAttribute imgAtt = xmlDocument.CreateAttribute(XMLPreparer.ATT_IMAGE);

            heightAtt.Value = remotePicFrame.Image.Size.Height.ToString();
            widthAtt.Value = remotePicFrame.Image.Size.Width.ToString();
            imgAtt.Value = TitleExporter(remotePicFrame.ImageLocation);

            XmlNode layoutNode = layoutTag;
            layoutNode.Attributes.Append(heightAtt);
            layoutNode.Attributes.Append(widthAtt);
            layoutNode.Attributes.Append(imgAtt);
        }

        private string TitleExporter(string imagePath)
        {
            Console.WriteLine(imagePath.Substring(imagePath.LastIndexOf("\\")));
            return imagePath.Substring(imagePath.LastIndexOf("\\")+1);
        }
    }
}