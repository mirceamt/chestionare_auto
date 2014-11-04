using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChestionareAuto
{
    public class QuestionClass
    {
        private int index;
        private String question, ansA, ansB, ansC, ansCorrect, photoPath;
        private bool existsImage;
        #region Constructori
        public QuestionClass()
        {
            index = 0;
            photoPath = question = ansA = ansB = ansC = ansCorrect = "";
            existsImage = false;
        }
        public QuestionClass(int _index, String _question, String _ansA, String _ansB, String _ansC, String _ansCorrect, bool _existsImage)
        {
            this.index = _index;
            this.question = _question;
            this.ansA = _ansA;
            this.ansB = _ansB;
            this.ansC = _ansC;
            this.ansCorrect = _ansCorrect;
            this.existsImage = _existsImage;
        }
        public QuestionClass(int _index, String _question, String _ansA, String _ansB, String _ansC, String _ansCorrect, bool _existsImage, String _photoPath)
        {
            this.index = _index;
            this.question = _question;
            this.ansA = _ansA;
            this.ansB = _ansB;
            this.ansC = _ansC;
            this.ansCorrect = _ansCorrect;
            this.existsImage = _existsImage;
            this.photoPath = _photoPath;
        }
        #endregion
        #region Proprietati
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = (value >= 0) ? value : 0;
            }
        }
        public String Question
        {
            get
            {
                return question;
            }
            set
            {
                this.question = value;
            }
        }
        public String AnsA
        {
            get
            {
                return ansA;
            }
            set
            {
                this.ansA = value;
            }
        }
        public String AnsB
        {
            get
            {
                return ansB;
            }
            set
            {
                this.ansB = value;
            }
        }
        public String AnsC
        {
            get
            {
                return ansC;
            }
            set
            {
                this.ansC = value;
            }
        }
        public String AnsCorrect
        {
            get
            {
                return ansCorrect;
            }
            set
            {
                this.ansCorrect = value;
            }
        }
        public bool ExistsImage
        {
            get
            {
                return existsImage;
            }
            set
            {
                this.existsImage = value;
            }
        }
        public String PhotoPath
        {
            get
            {
                return photoPath;
            }
            set
            {
                this.photoPath = value;
            }

        }
        #endregion
    }
}
