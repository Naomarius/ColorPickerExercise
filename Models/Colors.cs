using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Models
{
    public class Colors
    {
        private List<Color> colorsList = new List<Color>();

        public List<Color> ColorsList
        {
            get
            {
                if (colorsList.Count == 0)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Color>));

                    //get colors from XML file
                    using (FileStream stream = File.OpenRead(
                        @"c:\users\z777ik\documents\visual studio 2013\Projects\ColorPickerCodingExercise\Model\Data\ColorData.xml"))
                    {
                        colorsList = (List<Color>)serializer.Deserialize(stream);
                    }
                }

                return colorsList;
            }
            set 
            {
                if (value != null)
                { 
                    colorsList = value; 
                }
            }
        }
    }

    public class Color
    {
        public string colorName = string.Empty;

        public Color()
        {
        }

        public Color(string newColor)
        {
            colorName = newColor;
        }
    }
}
