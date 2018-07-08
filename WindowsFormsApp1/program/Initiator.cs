using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LayoutProject.program
{
    class Initiator : XMLReaderCallback, XMLPreparerCallback, IValuesWriterCallback
    {

        //instances
        private XMLReader xmlReader;
        private XMLPreparer xmlPreparer;
        private ValuesWriter valuesWriter;
        private InitiatorCallBack callBack;


        public Initiator(InitiatorCallBack callBack)
        {
            this.callBack = callBack;
            xmlReader = new XMLReader(this);
            xmlPreparer = new XMLPreparer();
            valuesWriter = new ValuesWriter(this);
        }

        internal void RunPath(string xmlPath, string remotePath)
        {
            xmlReader.ReadXMLPath(xmlPath);
        }

        public void OnReadEnd(XmlDocument xmlDocument, string[] xmlNodesNamesList)
        {
            xmlPreparer.PrepareXML(this, xmlDocument, xmlNodesNamesList);
        }

        public void OnXmlPrepareEnd(XmlDocument xmlDocument)
        {
            valuesWriter.IniWriteValues(xmlDocument);
        }

        public void OnWritingEnd(XmlDocument xmlDocument)
        {
            xmlDocument.Save(PathForm.GetXmlPath());
            callBack.onFileMade();
        }


    }

    public interface InitiatorCallBack
    {
        void onFileMade();
    }

}