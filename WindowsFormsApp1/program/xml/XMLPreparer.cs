using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using WindowsFormsApp1.program;
using WindowsFormsApp1.program.xml;

namespace LayoutProject.program
{
    internal class XMLPreparer
    {

        //instances
        private XMLPreparerCallback xmlPreparerCallback;

        private static string REMOTE_TAG = "remote";

        //layout tag params
        public static string TAG_LAYOUT = "layout";
        public static string ATT_IMAGE = "image";
        public static string ATT_WIDTH = "width";
        public static string ATT_HEIGHT = "height";
        private static string DEF_IMAGE_WIDTH = "348";
        private static string DEF_IMAGE_HEIGHT = "1500";
        public static string VAL_PLACE_HOLDER = "$";


        //rect tag params
        public static string TAG_RECT = "rect";
        public static string ATT_NAME = "name";
        public static string ATT_X = "x";
        public static string ATT_Y = "y";
        public string EXTERNAL_COMMENT_MSG = "External Buttons!";
        private string TAG_REMOTE = "remote";
        private string NODE_VOL_UP = "device_vol+";
        private string NODE_VOL_DOWN = "device_vol-";
        private string NODE_VOL_MUTE = "device_mute";
        public static string ATT_TYPE = "type";

        internal void PrepareXML(Initiator initiator, XmlDocument xmlDocument, List<string> xmlNodesNamesList)
        {
            this.xmlPreparerCallback = initiator;
            CheckIfLegal(xmlDocument);

            if (!PathForm.GetRunOver() && LayoutElementExists(xmlDocument))
            {
                xmlPreparerCallback.OnXmlPrepareEnd(xmlDocument);
                return;
            }

            if (PathForm.GetRunOver() && LayoutElementExists(xmlDocument))
            {
                //need to go to remote and delete the layout from there!
                XmlNode xmlnode = xmlDocument.GetElementsByTagName(TAG_REMOTE)[0];
                xmlnode.RemoveChild(xmlDocument.GetElementsByTagName(TAG_LAYOUT)[0]);
                xmlDocument.Save(PathForm.GetXmlPath());
            }

            XmlElement layoutElement = GetLayoutElement(xmlDocument);
            SetRectElementsTags(xmlDocument, layoutElement, xmlNodesNamesList);
            xmlDocument.Save(PathForm.GetXmlPath());
            xmlPreparerCallback.OnXmlPrepareEnd(xmlDocument);

        }


        private bool LayoutElementExists(XmlDocument xmlDocument)
        {
            return xmlDocument.GetElementsByTagName(TAG_LAYOUT).Count != 0;

        }

        private XmlElement GetLayoutElement(XmlDocument xmlDocument)
        {
            XmlElement layoutElement = xmlDocument.CreateElement(TAG_LAYOUT);
            return layoutElement;
        }

        private void SetRectElementsTags(XmlDocument xmlDocument, XmlElement layoutElement, List<string> xmlNodesNamesList)
        {
            int namesLength = xmlNodesNamesList.Count;
            for (int i = 0; i < namesLength; i++)
            {
                if (IsVolElement(xmlNodesNamesList[i])) continue;
                XmlElement rectElement = CreateRectElement(xmlDocument, xmlNodesNamesList[i]);
                layoutElement.AppendChild(rectElement);
            }

            SetTVBtns(xmlDocument, layoutElement);

            XmlNodeList remoteElements = xmlDocument.GetElementsByTagName(REMOTE_TAG);
            remoteElements[0].AppendChild(layoutElement);
        }

        private bool IsVolElement(string xmlNodeName)
        {
            return xmlNodeName.Equals(NODE_VOL_UP) || xmlNodeName.Equals(NODE_VOL_DOWN) || xmlNodeName.Equals(NODE_VOL_MUTE);
        }

        private void SetTVBtns(XmlDocument xmlDocument, XmlElement layoutElement)
        {
            if (TvBtns.TvBtnsDict.Count != 0)
            {
                layoutElement.AppendChild(xmlDocument.CreateComment(EXTERNAL_COMMENT_MSG));
                SetRectTVElementsTags(xmlDocument, layoutElement);
            }
        }

        private void SetRectTVElementsTags(XmlDocument xmlDocument, XmlElement layoutElement)
        {

            //addComment(xmlDocument, layoutElement);
            foreach (string tvItemStr in TvBtns.TvBtnsDict.Keys)
            {
                if (TvBtns.TvBtnsDict[tvItemStr])
                {
                    if (IsVolElement(tvItemStr)) continue;
                    XmlElement rectElement = CreateRectElement(xmlDocument, tvItemStr);
                    layoutElement.AppendChild(rectElement);
                }
            }
        }

        private XmlElement CreateRectElement(XmlDocument xmlDocument, string rectName)
        {
            XmlElement rectElement = xmlDocument.CreateElement(TAG_RECT);
            rectElement.SetAttribute(ATT_NAME, rectName);
            rectElement.SetAttribute(ATT_X, VAL_PLACE_HOLDER);
            rectElement.SetAttribute(ATT_Y, VAL_PLACE_HOLDER);
            rectElement.SetAttribute(ATT_WIDTH, VAL_PLACE_HOLDER);
            rectElement.SetAttribute(ATT_HEIGHT, VAL_PLACE_HOLDER);
            return rectElement;
        }


        private void CheckIfLegal(XmlDocument xmlDocument)
        {
            XmlNodeList remoteElements = xmlDocument.GetElementsByTagName(REMOTE_TAG);
            if (remoteElements.Count == 0)
                throw new Exception("COULDNT FIND THE REMOTE TAG!");
        }



    }

    internal interface XMLPreparerCallback
    {
        void OnXmlPrepareEnd(XmlDocument xmlDocument);
    }




}