namespace LZ_translate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void initialize_textbox()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            return;
        }



        private void button1_Click(object sender, EventArgs e)// LZ •ÏŠ·
        {
            initialize_textbox();
            string  input_line = textBox1.Text;


            if(!check_text_is_correct(input_line))
            {
                textBox3.Text = "this text is invalid";
                return;
            }

            textBox2.Text += translate_to_LZ(ref input_line);
            textBox3.Text = "traslate sucessfully";
            

        }

        private bool check_text_is_correct(string line)
        {

            for(int i = 0; i < line.Length; i++)
            {
                if (!(line[i] == '0' || line[i] == '1'))
                {
                    return false;

                }
            }

            return true;

        }

        private string translate_to_LZ(ref string line)
        {

            var LZ_pieces = new List<string>();

            string LZ_piece = "";
            string output_line = "";
            int same_text_number = 0;


            for(int i = 0; i < line.Length; i++)
            {
                LZ_piece += line[i];

                if (LZ_pieces.Contains(LZ_piece))
                {
                    same_text_number = LZ_pieces.IndexOf(LZ_piece) + 1;
                }
                else
                {
                    output_line += translate_to_binary_number(same_text_number, LZ_pieces.Count) + line[i];

                    LZ_pieces.Add(LZ_piece);
                    LZ_piece = "";
                    same_text_number = 0;

                }
            }

            if(LZ_piece != "")
            {
                output_line+= translate_to_binary_number(same_text_number , LZ_pieces.Count);
                LZ_pieces.Add(LZ_piece);
            }



            return output_line;
        }

        private string translate_to_binary_number(int text_num , int pieces_num)// num is just a num, counter is counter
        {
            string output_line = Convert.ToString(text_num,2);

            int line_length = output_line.Length;

            int counter_length = Convert.ToString(pieces_num, 2).Length;

            string front_zero = "";

            for(int i = 0; i < counter_length - line_length; i++)
            {
                front_zero += "0";
            }

            if(pieces_num == 0)
            {
                return "";
            }

            return front_zero + output_line;
        }

        private void button2_Click(object sender, EventArgs e)//‹tLZ•ÏŠ·
        {
            initialize_textbox();
            string input_line = textBox1.Text;


            if (!check_text_is_correct(input_line))
            {
                textBox3.Text = "this text is invalid";
                return;
            }

            textBox2.Text += restore_lz_translate(ref input_line);
            textBox3.Text = "traslate sucessfully";

        }

        private string restore_lz_translate(ref string input_line)
        {

            var LZ_set = new List<string>();
            var LZ_set_num = ajust_list_length(input_line);

            var LZ_set_piece = "";
            string output_line = "";
            int searched_num = 0;

            for(int i = 0; i < LZ_set_num.Count; i++)
            {
            }

            return string.Join(" " , LZ_set_num);
        }

        private List<int> ajust_list_length(string input_line)
        {
            var LZ_set_num  = new List<int>();

            int i = 0;
            int instant_sum = 0;
            while (instant_sum < input_line.Length)
            {
                int instant_num = Convert.ToString(i, 2).Length;

                if (i != 0)
                {
                    instant_num++;
                }

                LZ_set_num.Add(instant_num);
                instant_sum += instant_num;

                i++;

            }
            return LZ_set_num;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)// input
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)// output
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string save_line = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = save_line;

            return;

        }
    }
}