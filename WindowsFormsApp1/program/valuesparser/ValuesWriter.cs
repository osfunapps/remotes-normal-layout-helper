using LayoutProject.program.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApp1.program.example;
using static WindowsFormsApp1.program.example.RemotePicFrame;
using WindowsFormsApp1.program.valuesparser;

namespace LayoutProject.program
{
    class ValuesWriter : IRemotePicFrameCallback
    {

        //instances
        private MouseCoordinator mouseCoordinator;
        private IValuesWriterCallback valuesWriterCallback;

        //xml instances
        private XmlNode layoutElement;
        private XmlNodeList rectNodesList;
        private XmlNode currentRectNode;
        private XmlDocument xmlDocument;

        //params
        private int rectNodesCount;
        private int nodesIndexer;
        private XmlAttribute missingAttName;
        private RemotePicFrame remotePicFrame;

        public ValuesWriter(Initiator initiator)
        {
            this.valuesWriterCallback = initiator;
            remotePicFrame = new RemotePicFrame(this);
        }

        internal void IniWriteValues(XmlDocument xmlDocument)
        {
            SetParams(xmlDocument);
            this.mouseCoordinator = new MouseCoordinator();
            mouseCoordinator.ShowDialog();
            IniRemotePic(xmlDocument);
            CheckNextVal();
        }

        private void IniRemotePic(XmlDocument xmlDocument)
        {
            remotePicFrame.GetRemotePic().ImageLocation = PathForm.getRemotePicPath();

            Task t = Task.Run(() =>
            {
                remotePicFrame.ShowDialog();
            });
        }

        private void SetParams(XmlDocument xmlDocument)
        {
            this.layoutElement = xmlDocument.GetElementsByTagName(XMLPreparer.TAG_LAYOUT)[0];
            this.xmlDocument = xmlDocument;
            this.rectNodesList = xmlDocument.GetElementsByTagName(XMLPreparer.TAG_RECT);
            this.rectNodesCount = layoutElement.ChildNodes.Count;
            this.nodesIndexer = 0;
            this.currentRectNode = rectNodesList[nodesIndexer];
        }

        private void CheckNextVal()
        {
            if (currentRectNode == null) return;

            XmlAttributeCollection attributesList = currentRectNode.Attributes;
            string currentNodeName = currentRectNode.Attributes[XMLPreparer.ATT_NAME].Value;

            foreach (XmlAttribute att in attributesList)
            {
                if (NodeUnFinished(att.Value))
                {
                    this.missingAttName = att;
                    mouseCoordinator.ShowMouseNotification(currentNodeName);
                    return;
                }
            }

            currentRectNode = rectNodesList[++nodesIndexer];

            if (LastElement())
            {
                remotePicFrame.OnDone();
                new RemoteDimensHandler().SetRemoteDimens(xmlDocument, remotePicFrame.GetRemotePic());
                valuesWriterCallback.OnWritingEnd(xmlDocument);
                return;
            }

            CheckNextVal();

        }

        private bool LastElement()
        {
            return nodesIndexer  == rectNodesList.Count;
        }

        private bool NodeUnFinished(string attVal)
        {
            string name = currentRectNode.Attributes[XMLPreparer.ATT_NAME].Value;
            return attVal.Equals(XMLPreparer.VAL_PLACE_HOLDER);

        }


        public void OnBtnMarked(RectNodeObj rectObj)
        { 
            if (currentRectNode == null)
            {
                mouseCoordinator.ShowMouseNotification("YEYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");
                Application.Exit();
                return;
            }
            currentRectNode.Attributes[XMLPreparer.ATT_X].Value = rectObj.getX();
            currentRectNode.Attributes[XMLPreparer.ATT_Y].Value = rectObj.getY();
            currentRectNode.Attributes[XMLPreparer.ATT_WIDTH].Value = rectObj.getWidth();
            currentRectNode.Attributes[XMLPreparer.ATT_HEIGHT].Value = rectObj.getHeight();

            xmlDocument.Save(PathForm.GetXmlPath());
            CheckNextVal();
        }

        public void OnBtnUndo()
        {
            if (nodesIndexer != 0)
                nodesIndexer--;
            this.currentRectNode = rectNodesList[nodesIndexer];

            XmlAttributeCollection attributesList = currentRectNode.Attributes;
            foreach (XmlAttribute att in attributesList)
            {
                if (att.Name == "name") continue;
                att.Value = XMLPreparer.VAL_PLACE_HOLDER;
            }
            remotePicFrame.ClearLastRect();
            CheckNextVal();
        }
    }

    internal interface IValuesWriterCallback
    {
        void OnWritingEnd(XmlDocument xmlDocument);
    }



}
