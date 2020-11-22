using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    class Note
    {
        private Exam ExamNote { get; set; }
        private float NoteValue { get; set; }
        public Note(Exam _examNote,float _noteValue)
        {
            ExamNote = _examNote;
            NoteValue=_noteValue;
        }
    }
}
