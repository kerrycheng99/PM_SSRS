using System;
using System.Web.UI.WebControls;


/// <summary>
/// Class1 �̊T�v�̐����ł��B
/// </summary>
namespace PMClass
{
    public class ComConst
    {
        public const int SUCCEED = 0;
        public const int FAILED = -1;
        public const int CHECK_ERROR = -2;
        public const int TRIGGER_ERROR = -2;
        public const int ROUTE_SET_ERROR = -3;
        public const int LOOP_ERROR = -4;

        //
        // �c�a�֘A�̒萔�錾
        //
        public const int DB_SEL = 0;
        public const int DB_NEXT = 1;
        public const int DB_CLOSE = 2;
        public const int DB_SELC = 3;

        public const int DB_RTN = 0;
        public const int DB_IN = 1;
        public const int DB_INOUT = 2;
        public const int DB_OUT = 3;

        //
        // Login�֘A�̒萔
        //
        public const int PWD_CHG = -1;
        public const int PWD_UNMATCH = -2;
        public const int USER_LOCKED = -3;
        public const int USER_UNMATCH = -4;
        public const int PWD_NO_CHG = -5;
        public const int PWD_MIN_LEN_ERR = -6;
        public const int SYS_PARA_ERR = -7;
        public const int PWD_NO_CHG1 = -8;
        public const int PWD_NO_CHG2 = -9;
        public const int PWD_NO_CHG3 = -10;

        //
        // DB�X�V�G���[�֘A�̒萔
        //
        public const int UNABLE_TO_DELETE = -2;

        

        //
        // ���[���֘A�̒萔
        //
        public class Mail
        {
            /// <summary>
            /// �G���R�[�f�B���O
            /// </summary>
            public class BodyEncoding
            {
                public const string None = "";            // �w��Ȃ���UTF-8
                public const string Shift_jis = "shift_jis";        // ���{�� �V�t�gJIS
                public const string Euc_jp = "euc-jp";              // ���{�� EUC
                public const string Iso_2022_jp = "iso-2022-jp";    // ���{�� JIS
                public const string CsISO2022JP = "csISO2022JP";    // ���{�� JIS(1�o�C�g�J�^�J�i��)
                public const string Utf_8 = "utf-8";                // UTF-8
            }
            /// <summary>
            /// �t�H�[�}�b�g�`��
            /// </summary>
            public class BodyFormat
            {
                public const string None = "";            // �w��Ȃ�
                public const string Text = "TEXT";        // TEXT
                public const string Html = "HTML";        // HTML
            }
            /// <summary>
            /// �D�揇��
            /// </summary>
            public class Prioryty
            {
                public const string High = "HIGH";
                public const string Low = "LOW";     
                public const string Normal = "NORMAL";
            }

        }



        public ComConst()
        {
            // 
            // TODO: �R���X�g���N�^ ���W�b�N�������ɒǉ����Ă��������B
            //
        }

      

    }
}
