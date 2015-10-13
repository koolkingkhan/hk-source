using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace DataTemplateSample
{
    public class ImagesCollection
    {
        private readonly List<string> _pathCollection = new List<string>();

        public List<string> PathCollection
        {
            get
            {
                if (_pathCollection.Count == 0)
                {
                    string imagesDirectory = Path.GetFullPath(@"..\..\Images");
                    _pathCollection.Add(Path.Combine(imagesDirectory, "Sunset.jpg"));
                    _pathCollection.Add(Path.Combine(imagesDirectory, "Sample1.jpg"));
                    _pathCollection.Add(Path.Combine(imagesDirectory, "Blue hills.jpg"));
                    _pathCollection.Add(Path.Combine(imagesDirectory, "Water lilies.jpg"));
                    _pathCollection.Add(Path.Combine(imagesDirectory, "Sample2.jpg"));
                    _pathCollection.Add(Path.Combine(imagesDirectory, "Winter.jpg"));
                }
                return _pathCollection;
            }
        }
    }
}
