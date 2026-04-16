using System;

namespace Gruppe6Genspil
{
    public class IdManager
    {
        private int _nextId = 0;
        public int GetNextId()
        {
            int nextId = _nextId;
            _nextId++;
            return nextId;
        }
    }
}
