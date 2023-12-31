﻿using Explorer.ViewModels.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Explorer.ViewModels.History
{
    public class DirectoryHistory
    {
        private DirectoryNode _head;
        private DirectoryNode _current;

        public DirectoryViewModel Current => _current.Current;
        public event EventHandler<EventArgs> HistoryChanged;
        public bool CanMoveNext => _current.Next != null;
        public bool CanMovePrevious => _current.Previous != null;
        public DirectoryHistory(DirectoryViewModel dirVM)
        {
            _head = new DirectoryNode() { Current = dirVM };
            _current = _head;
        }
        private void RaiseHistoryChanged()
        {
            HistoryChanged?.Invoke(null, EventArgs.Empty);
        }
        public void AddNode(DirectoryViewModel dirVM)
        {
            //_current.Next.Dispose();
            _current.Next = new DirectoryNode()
            {
                Previous = _current,
                Current = dirVM,
                Next = null
            };
            MoveNext();
        }
        
        public void MoveNext()
        {
            _current = _current?.Next;
            RaiseHistoryChanged();
        }
        public void MovePrevious() 
        {
            _current = _current?.Previous;
            RaiseHistoryChanged();
        }
    }
}
