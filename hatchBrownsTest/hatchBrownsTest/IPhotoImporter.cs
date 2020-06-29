using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace hatchBrownsTest
{
    public interface IPhotoImporter
    {
        Task<ObservableCollection<Photo>> Get(int startIndex, int count, Quality quality = Quality.Low);
        Task<ObservableCollection<Photo>> Get(List<string> filenames, Quality quality = Quality.Low);
    }
    public enum Quality
    {
        Low,
        High
    }
}
