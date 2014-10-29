using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Models
{
    public class Users
    {
        private List<User> usersList = new List<User>();

        public List<User> UsersList
        {
            get 
            {
                if (usersList.Count == 0)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Color>));

                    //get colors from XML file
                    using (FileStream stream = File.OpenRead(
                        @"c:\users\z777ik\documents\visual studio 2013\Projects\ColorPickerCodingExercise\Model\Data\UserData.xml"))
                    {
                        usersList = (List<User>)serializer.Deserialize(stream);
                    }
                }

                return usersList; 
            }
        }

        public void AddUser(string newUser, Color usersColorofChoice)
        {
            usersList.Add(new User(newUser, usersColorofChoice));
        }

        public void AddUser(string newUser, string usersColorofChoice)
        {
            usersList.Add(new User(newUser, new Color(usersColorofChoice)));
        }
    }

    public class User
    {
        public string userName = string.Empty;
        public Color usersColorChoice = new Color();

        public User()
        {
        }

        public User(string newUser, Color newColor)
        {
            userName = newUser;
            usersColorChoice = newColor;
        }
    }
}
