using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Note
    {
        public Exam ExamNote { get; set; }
        public float NoteValue { get; set; }
        public Note(Exam _examNote,float _noteValue)
        {
            ExamNote = _examNote;
            NoteValue=_noteValue;
        }
        public string Information()
        {
            return $"NOTE : {NoteValue} \n{ExamNote.Information()}";
        }
    }
}
