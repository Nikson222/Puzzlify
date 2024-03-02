using Models;

namespace _Scripts.Signals
{
    public class ClickItemGallerySignal
    {
        public GalleryItemModel Model;

        public ClickItemGallerySignal(GalleryItemModel model)
        {
            Model = model;
        }
    }
}