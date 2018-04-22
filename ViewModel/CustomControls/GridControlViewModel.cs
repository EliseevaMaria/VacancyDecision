using System;
using System.Collections.Generic;
using Database.Repository;
using Model.Entity;

namespace ViewModel.CustomControls
{
    public class GridControlViewModel<T> : BaseViewModel where T : BaseEntity, new()
    {
        public void CreateRecord(T entity)
        {
            this.repository.CreateRecord(entity);
            this.RefreshRecordList();
        }

        public void Delete()
        {
            this.repository.Delete(this.SelectedRecord);
            this.RefreshRecordList();
        }

        public GridControlViewModel(BaseRepository<T> repository)
        {
            this.repository = repository;
        }

        protected List<T> recordList;
        public List<T> RecordList
        {
            get
            {
                return this.recordList ?? (this.recordList = this.repository.GetRecords());
            }
            set
            {
                if (this.recordList == value)
                    return;

                this.recordList = value;
                this.OnPropertyChanged(nameof(this.RecordList));
            }
        }

        public void RefreshRecordList(string where = "")
        {
            this.RecordList = this.repository.GetRecords(where);
        }

        protected BaseRepository<T> repository;

        private T selectedRecord;
        public T SelectedRecord
        {
            get
            {
                return this.selectedRecord;
            }
            set
            {
                if (this.selectedRecord == value)
                    return;

                this.selectedRecord = value;
                this.OnPropertyChanged(nameof(this.SelectedRecord));
            }
        }

        public void UpdateRecord(T entity)
        {
            this.repository.UpdateRecord(entity);
            this.RefreshRecordList();
        }
    }
}
