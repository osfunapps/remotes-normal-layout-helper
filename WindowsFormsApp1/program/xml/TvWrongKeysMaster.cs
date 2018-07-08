using LayoutProject;
using LayoutProject.program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp1.program.xml
{
    class TvWrongKeysMaster
    {
        private string KEY_TV = "tv", KEY_AV = "av", KEY_VOL_UP = "vol_up", KEY_VOL_DOWN = "vol_down", KEY_MUTE = "mute";

        internal String[] RemoveWrongTvKeys(XmlDocument xmlDocument)
        {
            XmlNode papaKeyNode = xmlDocument.GetElementsByTagName(XMLReader.ATT_KEYS)[0];
            int papaChildsCount = papaKeyNode.ChildNodes.Count;

            //we will make two lists: one for the names and one for the correct node values (all of the key nodes without the tv ones)
            List<XmlNode> keysNodesList = new List<XmlNode>();
            List<string> keyNames = new List<string>();

            foreach (XmlNode keyNode in papaKeyNode.ChildNodes)
            {

                //if it is a tv node, ignore it and dont add it to the list
                string keyName = keyNode.Attributes[XMLPreparer.ATT_NAME].Value;
                if (keyName.Equals(KEY_TV) || keyName.Equals(KEY_AV) || keyName.Equals(KEY_VOL_UP) || keyName.Equals(KEY_VOL_DOWN) || keyName.Equals(KEY_MUTE))
                    continue;

                //else add it, and add it's name
                else
                {
                    keysNodesList.Add(keyNode.Clone());
                    keyNames.Add(keyName);
                }
            }

            //remove the keys from the keys papa and add the relevant one, one by one, to the empy papa
            papaKeyNode.RemoveAll();
            foreach (XmlNode keyNode in keysNodesList)
            {
                papaKeyNode.AppendChild(keyNode);
            }

            xmlDocument.Save(PathForm.GetXmlPath());
            return keyNames.ToArray();
        }
    }
}
