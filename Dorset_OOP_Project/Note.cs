using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Note
    {
        public Exam ExamNote { get; set; }
        public double NoteValue { get; set; }
        public Note(Exam _examNote, double _noteValue)
        {
            ExamNote = _examNote;
            NoteValue = _noteValue;
        }
        public Note()
        {

        }
        public string Information()
        {
            return $"NOTE : {NoteValue} \n{ExamNote.Information()}";
        }
    }
}
