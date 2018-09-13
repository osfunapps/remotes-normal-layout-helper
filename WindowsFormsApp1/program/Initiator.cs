using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApp1.program.tools;

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

        internal void RunPath(string appPathStr, string remotePath)
        {
            xmlReader.ReadXMLPath(appPathStr + Finals.PATH_ORIGINAL_CONFIG_FILE);
        }

        public void OnReadEnd(XmlDocument xmlDocument, List<string> xmlNodesNamesList)
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
            callBack.OnFileMade();
        }


        public void KillPreviousCycleElements()
        {
            valuesWriter.KillPreviousCycleElements();
        }
    }

    public interface InitiatorCallBack
    {
        void OnFileMade();
    }

}