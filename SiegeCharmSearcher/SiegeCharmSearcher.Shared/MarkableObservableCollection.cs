using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace SiegeCharmSearcher.Shared {
    public sealed class MarkableObservableCollection<T> : ObservableCollection<T> {
        public bool IsDirty { get; private set; }

        public MarkableObservableCollection() : base() => CollectionChanged += OnCollectionChanged;

        private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs) =>
            MarkDirty();

        public void MarkDirty() => IsDirty = true;

        internal string SerializeAsJson() {
            string json = JsonConvert.SerializeObject(this);
            IsDirty = false;
            return json;
        }

        internal void LoadFromJson(string path) {
            MarkableObservableCollection<T>? list =  JsonConvert.DeserializeObject<MarkableObservableCollection<T>?>(FileManager.ReadJson(path)) ?? throw new NullReferenceException();
            Clear();
            foreach (T item in list) {
                Add(item);
            }

            MarkDirty();
        }
    }
}