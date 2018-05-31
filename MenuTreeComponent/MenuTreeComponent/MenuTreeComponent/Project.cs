using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MenuTreeComponent
{
    public class Project
    {
        private MenuNode _root;

        private string _fileName;

        public MenuNode Root
        {
            get { return _root; }
        }

        public string Name
        {
            get { return _fileName; }
        }

        // constructor as deserializer
        public Project(string fileName_)
        {
            using(FileStream fs = File.OpenRead(fileName_))
            {
                DataContractSerializer formatter = new DataContractSerializer(typeof(MenuNode));
                this._root = formatter.ReadObject(fs) as MenuNode;
                this._fileName = fileName_;
            }
        }

        public void Serialize(string fileName_ = null)
        {
            string fileName = string.IsNullOrEmpty(fileName_) ? _fileName : fileName_;
            using (FileStream fs = File.OpenWrite(fileName)) {
                DataContractSerializer formatter = new DataContractSerializer(typeof(MenuNode));
                formatter.WriteObject(fs, this.Root);
            }
        }

        public MenuNode GetByNode(int[] path_, MenuNode current_ = null)
        {
            if(current_ == null)
            {
                return GetByNode(path_, this.Root);
            }
            else
            {
                if (path_.Length > 0)
                {
                    if (current_.Children.Count > path_[0])
                        return GetByNode(path_.Skip(1).ToArray(), current_.Children[path_[0]]);
                    else return null;
                }
                else return current_;
            }
        }
    }

    [DataContract(IsReference = true)]
    public class MenuNode
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<MenuNode> Children { get; set; }
    }
}
