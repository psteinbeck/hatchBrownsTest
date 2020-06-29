using System;
namespace hatchBrownsTest.Droid
{
    public interface PhotoImporter
    {
        public class PhotoImporter: IPhotoImporter
        {
            private bool hasCheckedPermission;
            private string[] result;

            public bool ContinueWithPermission(bool granted)
            {
                if (!granted)
                {
                    return false;
                }
            }
        }
    }
}
