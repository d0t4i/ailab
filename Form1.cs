using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace dattnt
{
    public partial class Form1 : Form
    {
        int ti = 0;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btngiai_Click(object sender, EventArgs e)
        {
           
            
            check(true);
        }
        private void check(bool cl = false)
        {
            data d = (data)boxChon.SelectedItem;
            if (d == null) return;
            if (d.i == 1)
            {
                if (cl == true)
                    taci();
                return;
            }
            else if (d.i == 2)
            {
                if (cl == true)
                    taci2();
                return;
            }
            
            
        }
        private void taci()
        {
           
            List<List<int>> box1 = this.getmt(txtbox1.Text.ToString());
            List<List<int>> box2 = this.getmt(txtbox2.Text.ToString());
            if (val(box1) == false || val(box2) == false || box1.Count != box2.Count)
            {
                ne();
                return;
            }
            btngiai.Enabled = false;
            tacid start = new tacid(box1);
            tacid end = new tacid(box2);
            atk run = new atk(end);
            
            run.start(start);
            

            
            run.go();
            btngiai.Enabled = true;
            
        }
        private void taci2()
        {

            List<List<int>> box1 = this.getmt(txtbox1.Text.ToString());
            List<List<int>> box2 = this.getmt(txtbox2.Text.ToString());
            if (val(box1) == false || val(box2) == false || box1.Count != box2.Count)
            {
                ne();
                return;
            }
            btngiai.Enabled = false;
            

            tacidh2 start = new tacidh2(box1);
            tacidh2 end = new tacidh2(box2);
            atk2 run = new atk2(end);
            
            run.start(start);
            
            

            run.go();
            btngiai.Enabled = true;
            
        }
        private void upT()
        {

            if (btngiai.Enabled == true)
            {
                ti = 0;
            }
            else
            {
                ti  ++;
                
            }
        }
        private bool val2(List<List<int>> l)
        {
            if (l.Count == 0) return false;
            int p = l[0].Count;

            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Count != p) return false;
            }
            return true;
        }
        private bool val(List<List<int>> l)
        {
            int s = l.Count;
            
            for (int i = 0; i < l.Count; i++)
            {
                
               if (s != l[i].Count) return false;
                
            }
            if (s == 0) return false;
            return true;
        }
        private void pr(List<int> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                MessageBox.Show(a[i].ToString());
            }
        }
        private List<List<int>> getmt(string s)
        {
            List<List<int>> k = new List<List<int>>();
            string[] d = s.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string n in d)
            {
                List<int> p = this.getA(n);
                if (p.Count == 0) continue;
                k.Add(p);
            }
            return k;
        }
        private List<int> getA(string s)
        {
            List<int> a = new List<int>();
            try
            {
                string[] i = s.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < i.Length; j++)
                    a.Add(int.Parse( i[j]));
            }
            catch
            {
                ne();
            }
            return a;
        }
        private void ne()
        {
            MessageBox.Show("Dữ liệu không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.upT();
            boxChon.Items.Add(new data(1,"Taci - H1") );
            boxChon.Items.Add(new data(2, "Taci - H2"));
        }
        

  

        private void boxChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            check();
        }

        private void btnpause_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            upT();
        }
    }
    class data {
        public int i { get; set; }
        public string n { get; set; }
        
        public data(int i, string n)
        {
            this.i = i;
            this.n = n;

        }
        public override string ToString()
        {

            return n;
        }
    }
    
    class atk {

        List<tacid> open = new List<tacid>();
        List<tacid> close = new List<tacid>();
        List<tacid> cg = new List<tacid>();
        tacid r;
        tacid e;
        tacid s;
        int cl = 0;
        
        

        public atk(tacid r)
        {
            this.r = r;
        }
        public void ecl()
        {
            cl = 1;
            open.Clear();
            close.Clear();
            return;
        }
        public tacid findMin()
        {
            if (open.Count == 0) return null;
            int  min = 0;
            int f = open[0].f;
            for (int i = 0; i < open.Count; i++)
            {
                if (open[i].f < f)
                {
                    min = i;
                    f = open[i].f;
                }
            }
            return open[min];
        }
        public void removeOpen(tacid tc)
        {
            
            close.Add(tc);
            
            open.Remove(tc);
            
            
        }
        public void start(tacid s)
        {
            this.s = new tacid(s.clone());
            s.upF(r);
            this.open.Add(s);
        }
        public void go()
        {
            
            
            while (true)
            {
                if (open.Count == 0 && cl == 0 )
                {
                    MessageBox.Show("Không tìm thấy lời giải");
                    return;
                }
                tacid min = this.findMin();
                
                this.removeOpen(min);
                
                
                
                if (min.dif(r) == 0)
                {
                    this.e = min;
                    
                    break;
                }
                
                else
                {
                    this.addOpen(min);
                }
                
            }
            
            this.findE();
        }
        
        
        public void findE()
        {
            string n = " " + e.n;
            cg.Add(new tacid(e.clone(), e.n) );
            tacid crd = e;
            while (true)
            {
                if (crd.g == 0 || crd.prsc.Count == 0 ) break;

                tacid t = this.findP(crd);
                if (t == null) return;
                
                cg.Add(new tacid(t.clone(), t.n ));
                n = t.n + " - "+ n;
                crd = t;
            }
            if(n.Length > 3 )
                n = n.Substring(3);
            this.showR(n);
            
        }
        public void showR(string n)
        {
            MessageBox.Show(n,"Đã tìm thấy lời giải",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            this.write();

            DialogResult rd =  MessageBox.Show("Bạn có muốn hiển thị lời giải chi tiết","Thông tin", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rd == DialogResult.Yes)
            {
                int o = open.Count;
                int c = close.Count;
                int g = cg.Count - 1;
                int t = o + c;
                frmR f = new frmR(t, o, c, g);
                f.Show();
                
            }
        }
        public void showG()
        {
            for (int i = cg.Count - 1; i >=0 ; i--)
                cg[i].show();
        }
        public void write()
        {
            File.Delete("file.txt");
            int p = 0;
            for (int i = cg.Count - 1; i >= 0; i--)
            {
                
                File.AppendAllText("file.txt","g="+ p.ToString()+"\r\nBước đi: " );
                cg[i].write();
                p++;
            }
                
        }
        public tacid findP(tacid tc)
        {
            tacid t = new tacid ( tc.prsc) ;
            for(int i =0; i < close.Count; i++ )
            {
                if (close[i].dif(t) == 0) return close[i];
            }
            
            return null;
        }
        public bool isE()
        {
            for (int i = 0; i < open.Count; i++)
            {
                if (open[i].dif(r) == 0) return true;
            }
            return false;
        }
        
        
        public void addOpen(tacid tc)
        {
            
            int g = tc.g;
            List<string> cgo = tc.getGo();
            
            Console.WriteLine(open.Count.ToString() + " " + close.Count.ToString() + " " + tc.g.ToString() +" "+ tc.f.ToString() ) ;
            for (int i = 0; i < cgo.Count; i++)
            {
                List<List<int>> sc = tc.clone();
                tacid newtc = new tacid(sc,g);
                newtc.go(cgo[i].ToString());
                newtc.upF(r);
                
                bool iec = this.isEC(newtc);
                
                if (iec == false && this.isEO(newtc) == false)
                {
                    open.Add(newtc);
                }
                    
                
            }
        }
        
        

       
        public bool isEC(tacid tc)
        {
            for (int i = 0; i < close.Count; i++)
            {
                


                int kk = close[i].dif(tc);
                
                
                if (close[i].dif(tc) == 0) return true;
            }
            return false;
        }
        public bool isEO(tacid tc)
        {
            for (int i = 0; i < open.Count; i++)
            {
                


                int kk = open[i].dif(tc);

                
                if (open[i].dif(tc) == 0) return true;
            }
            return false;
        }
    }
    class tacid {
        string[] at = { "left", "right", "up", "down"} ;
        public string n = "";
        
        public int g=0;
        public int h=0;
        public int f=0;
        
        public List<List<int>> sc = new List<List<int>> ();
        public List<List<int>> prsc = new List<List<int>>();
        public tacid(List<List<int>> a)
        {
            this.sc = new List < List<int> > (a);
            
        }
        public tacid(List<List<int>> a, string n)
        {
            this.sc = new List<List<int>>(a);
            this.n = n;
        }
        public tacid(tacid p)
        {
            
            this.sc = new List<List<int>> ( p.sc ) ;
            this.g = p.g + 1;

        }
        public tacid(List<List<int>> a, int g)
        {
            this.sc = new List<List<int>>(a);
            this.prsc = this.clone();
            this.g = g + 1;
           
        }
        
        public void go(string n )
        {
            
            this.n = getN(n) +" " + n + "";
            this.lgo(n);
            

        }
        public List<List<int>> clone()
        {
            List < List<int> > ds = new List<List<int>>();
            for (int i = 0; i < this.sc.Count; i++)
            {
                List<int> k = new List<int>();
                for (int j = 0; j < this.sc[i].Count; j++)
                {
                    k.Add(sc[i][j]);
                }
                ds.Add(k);
            }
            return ds;
        }
        public void show()
        {
            string nd = this.n + "\n";
            for (int i = 0; i < this.sc.Count; i++)
            {
                for (int j = 0; j < this.sc[i].Count; j ++ )
                {
                    nd += this.sc[i][j].ToString() + "\t"; 
                }
                nd += "\n";
            }
            MessageBox.Show( nd, "Chi tiet loi giai ", MessageBoxButtons.OK);
        }
        public void showP()
        {
            string nd = " ";
            for (int i = 0; i < this.prsc.Count; i++)
            {
                for (int j = 0; j < this.prsc[i].Count; j++)
                {
                    nd += this.prsc[i][j].ToString() + "\t";
                }
                nd += "\n";
            }
            MessageBox.Show(nd);
        }
        public void write()
        {
            string nd = this.n + "\r\n";//this.n + "\n" + this.f + "\n";
            for (int i = 0; i < this.sc.Count; i++)
            {
                for (int j = 0; j < this.sc[i].Count; j++)
                {
                    nd += this.sc[i][j].ToString() + "\t";
                }
                nd += "\r\n\r\n\r\n";
            }
            
            
            File.AppendAllText("file.txt", nd);
            
        }
        public void upF(tacid tc)
        {
            this.ch1(tc);
            this.cf();
        }
        public void ch1(tacid tc)
        {
            int k = this.dif(tc) - 1;
            this.h = k;
        }
        public void cf()
        {
            this.f = g + h;
        }
        public int dif(tacid tc)
        {
            int t = 0;
            for (int i = 0; i < this.sc.Count; i++)
            {
                for (int j = 0; j < this.sc[i].Count; j++)
                {
                    if (this.sc[i][j] != tc.sc[i][j])
                        t++;
                }
            }
            return t;
        }
        public void lgo(string n )
        {
            int[] vt0 = fL0();
            if (n == at[0])
            {
                this.sc[vt0[0]][vt0[1]] = this.sc[vt0[0]][vt0[1] + 1];
                this.sc[vt0[0]][vt0[1] + 1] = 0;
            }
            if (n == at[1])
            {
                this.sc[vt0[0]][vt0[1]] = this.sc[vt0[0]][vt0[1] - 1];
                this.sc[vt0[0]][vt0[1] - 1] = 0;
            }
            if (n == at[2])
            {
                this.sc[vt0[0]][vt0[1]] = this.sc[vt0[0] +1][vt0[1]];
                this.sc[vt0[0] + 1][vt0[1]] = 0;
            }
            if (n == at[3])
            {
                this.sc[vt0[0]][vt0[1]] = this.sc[vt0[0] - 1][vt0[1]];
                this.sc[vt0[0] - 1][vt0[1]] = 0;
            }
        }
        public bool isEx(tacid tc)
        {
            if (this.dif(tc) > 0) return true;
            return false;
            
        }
        public List<string> getGo()
        {
            int[] vt0 = fL0();
            List<string> k = new List<string>();
            if (vt0[0] == -1) return k;
            k.Add(at[0]);
            k.Add(at[1]);
            k.Add(at[2]);
            k.Add(at[3]);
            if (vt0[0] == 0)
                k.Remove(at[3]);
            if (vt0[0] == this.sc.Count - 1)
                k.Remove(at[2]);
            if (vt0[1] == 0)
                k.Remove(at[1]);
            if (vt0[1] == this.sc[0].Count - 1)
                k.Remove(at[0]);
            return k;

        }
        public int[] fL0()
        {
            int[] k = new int[2];
            k[0] = -1;
            for (int i = 0; i < this.sc.Count; i++)
            {
                for (int j = 0; j < this.sc[i].Count; j++)
                {
                    if (this.sc[i][j] == 0)
                    {
                        k[0] = i;
                        k[1] = j;
                        return k;
                    }
                }
            }
            return k;
        }
        public void loi()
        {
            MessageBox.Show("Loi");
        }
        public string getN(string atg)
        {
            int[] vt0 = fL0();
            if (atg == at[2])
                return this.sc[vt0[0] + 1][vt0[1]].ToString();
            if (atg == at[3])
                return this.sc[vt0[0] - 1][vt0[1]].ToString();
            if (atg == at[0])
                return this.sc[vt0[0] ][vt0[1] +1 ].ToString();
            if (atg == at[1])
                return this.sc[vt0[0] ][vt0[1] -1].ToString();
            return null;

        }

    }
    class atk2
    {

        List<tacidh2> open = new List<tacidh2>();
        List<tacidh2> close = new List<tacidh2>();
        List<tacidh2> cg = new List<tacidh2>();
        tacidh2 r;
        tacidh2 e;
        tacidh2 s;
        int cl = 0;

        

        public atk2(tacidh2 r)
        {
            this.r = r;
        }
        public void ecl()
        {
            cl = 1;
            open.Clear();
            close.Clear();
            return;
        }
        public tacidh2 findMin()
        {
            if (open.Count == 0) return null;
            int min = 0;
            int f = open[0].f;
            for (int i = 0; i < open.Count; i++)
            {
                if (open[i].f < f)
                {
                    min = i;
                    f = open[i].f;
                }
            }
            return open[min];
        }
        public void removeOpen(tacidh2 tc)
        {
            
            close.Add(tc);
            
            open.Remove(tc);
            

        }
        public void start(tacidh2 s)
        {
            this.s = new tacidh2(s.clone());
            this.open.Add(s);
        }
        public void go()
        {

            
            while (true)
            {
                if (open.Count == 0 && cl == 0)
                {
                    MessageBox.Show("Không tìm thấy lời giải");
                    return;
                }
                tacidh2 min = this.findMin();
                
                this.removeOpen(min);
                


                if (min.dif(r) == 0)
                {
                    this.e = min;
                    
                    break;
                }

                else
                {
                    this.addOpen(min);
                }

            }
            
            this.findE();
        }


        public void findE()
        {
            string n = " " + e.n;
            cg.Add(new tacidh2(e.clone(), e.n));
            tacidh2 crd = e;
            while (true)
            {
                if (crd.g == 0 || crd.prsc.Count == 0) break;

                tacidh2 t = this.findP(crd);
                if (t == null) return;
                
                cg.Add(new tacidh2(t.clone(), t.n));
                n = t.n + " - " + n;
                crd = t;
            }
            if (n.Length > 3)
                n = n.Substring(3);
            this.showR(n);

        }
        public void showR(string n)
        {
            MessageBox.Show(n, "Đã tìm thấy lời giải", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            this.write();

            DialogResult rd = MessageBox.Show("Bạn có muốn hiển thị lời giải chi tiết", "Thông tin", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rd == DialogResult.Yes)
            {
                int o = open.Count;
                int c = close.Count;
                int g = cg.Count - 1;
                int t = o + c;
                frmR f = new frmR(t, o, c, g);
                f.Show();
                
            }
        }
        public void showG()
        {
            for (int i = cg.Count - 1; i >= 0; i--)
                cg[i].show();
        }
        public void write()
        {
            File.Delete("file.txt");
            int p = 0;
            for (int i = cg.Count - 1; i >= 0; i--)
            {

                File.AppendAllText("file.txt", "g=" + p.ToString() + "\r\nBước đi: ");
                cg[i].write();
                p++;
            }

        }
        public tacidh2 findP(tacidh2 tc)
        {
            tacidh2 t = new tacidh2(tc.prsc);
            for (int i = 0; i < close.Count; i++)
            {
                if (close[i].dif(t) == 0) return close[i];
            }

            return null;
        }


        public void addOpen(tacidh2 tc)
        {
            
            List<string> cgo = tc.getGo();
            
            Console.WriteLine(open.Count.ToString() + " " + close.Count.ToString() + " " + tc.g.ToString() + " " + tc.f.ToString());
            for (int i = 0; i < cgo.Count; i++)
            {
                
                tacidh2 newtc = new tacidh2(tc);
                newtc.go(cgo[i].ToString());
                newtc.upF(r);
                
                bool iec = this.isEC(newtc);
                
                if (iec == false && this.isEO(newtc) == false)
                {
                    open.Add(newtc);
                }

                
            }
        }




        public bool isEC(tacidh2 tc)
        {
            for (int i = 0; i < close.Count; i++)
            {
                


                int kk = close[i].dif(tc);

                
                if (close[i].dif(tc) == 0) return true;
            }
            return false;
        }
        public bool isEO(tacidh2 tc)
        {
            for (int i = 0; i < open.Count; i++)
            {



                int kk = open[i].dif(tc);


                if (open[i].dif(tc) == 0) return true;
            }
            return false;
        }
    }

    class tacidh2
    {
        string[] at = { "left", "right", "up", "down" };
        public string n = "";
        
        public int g = 0;
        public int h = 0;
        public int f = 0;
        public int olt = 0;
       
        public List<List<int>> sc = new List<List<int>>();
        public List<List<int>> prsc = new List<List<int>>();
        public tacidh2(List<List<int>> a)
        {
            this.sc = new List<List<int>>(a);

        }
        public tacidh2(List<List<int>> a, string n)
        {
            this.sc = new List<List<int>>(a);
            this.n = n;
        }
        public tacidh2(tacidh2 p)
        {

            this.sc = p.clone();
            this.g = p.g + 1;
            this.prsc = p.clone();
            this.h = p.h;


        }
        public tacidh2(List<List<int>> a, int g)
        {
            this.sc = new List<List<int>>(a);
            this.prsc = this.clone();
            this.g = g + 1;
            
        }

        public void go(string n)
        {
            
            this.olt = int.Parse(getN(n));

            this.n = getN(n) + " " + n + "";
            this.lgo(n);


        }
        private void ch2(tacidh2 r)
        {
            int[] a = fli(olt, this.prsc);
            int[] b = fli(olt, this.sc);

            if (itl(r, a) == true && itl(r, b) == false)
            {
                this.h = h + 1;
            }
            else if (itl(r, a) == false && itl(r, b) == true)
            {
                this.h = h - 1;
            }


        }
        private bool itl(tacidh2 r, int[] p)
        {
            if (r.sc[p[0]][p[1]] == olt) return true;
            return false;
        }
        private int[] fli(int p, List<List<int>> sco)
        {
            int[] k = new int[2];
            k[0] = -1;
            k[1] = -1;
            for (int i = 0; i < sco.Count; i++)
            {
                for (int j = 0; j < sco[i].Count; j++)
                {
                    if (sco[i][j] == p)
                    {
                        k[0] = i;
                        k[1] = j;
                    }
                }
            }
            return k;
        }
        public List<List<int>> clone()
        {
            List<List<int>> ds = new List<List<int>>();
            for (int i = 0; i < this.sc.Count; i++)
            {
                List<int> k = new List<int>();
                for (int j = 0; j < this.sc[i].Count; j++)
                {
                    k.Add(sc[i][j]);
                }
                ds.Add(k);
            }
            return ds;
        }
        public void show()
        {
            string nd = this.n + "\n";
            for (int i = 0; i < this.sc.Count; i++)
            {
                for (int j = 0; j < this.sc[i].Count; j++)
                {
                    nd += this.sc[i][j].ToString() + "\t";
                }
                nd += "\n";
            }
            MessageBox.Show(nd, "Chi tiet loi giai ", MessageBoxButtons.OK);
        }
        public void showP()
        {
            string nd = " ";
            for (int i = 0; i < this.prsc.Count; i++)
            {
                for (int j = 0; j < this.prsc[i].Count; j++)
                {
                    nd += this.prsc[i][j].ToString() + "\t";
                }
                nd += "\n";
            }
            MessageBox.Show(nd);
        }
        public void write()
        {
            string nd = this.n + "\r\n";//this.n + "\n" + this.f + "\n";
            for (int i = 0; i < this.sc.Count; i++)
            {
                for (int j = 0; j < this.sc[i].Count; j++)
                {
                    nd += this.sc[i][j].ToString() + "\t";
                }
                nd += "\r\n\r\n\r\n";
            }
            

            File.AppendAllText("file.txt", nd);
            
        }
        public void upF(tacidh2 tc)
        {
            this.ch2(tc);
            this.cf();
        }
        public void cf()
        {
            this.f = g + h;
        }
        public int dif(tacidh2 tc)
        {
            int t = 0;
            for (int i = 0; i < this.sc.Count; i++)
            {
                for (int j = 0; j < this.sc[i].Count; j++)
                {
                    if (this.sc[i][j] != tc.sc[i][j])
                        t++;
                }
            }
            return t;
        }
        public void lgo(string n)
        {
            int[] vt0 = fL0();
            if (n == at[0])
            {
                this.sc[vt0[0]][vt0[1]] = this.sc[vt0[0]][vt0[1] + 1];
                this.sc[vt0[0]][vt0[1] + 1] = 0;
            }
            if (n == at[1])
            {
                this.sc[vt0[0]][vt0[1]] = this.sc[vt0[0]][vt0[1] - 1];
                this.sc[vt0[0]][vt0[1] - 1] = 0;
            }
            if (n == at[2])
            {
                this.sc[vt0[0]][vt0[1]] = this.sc[vt0[0] + 1][vt0[1]];
                this.sc[vt0[0] + 1][vt0[1]] = 0;
            }
            if (n == at[3])
            {
                this.sc[vt0[0]][vt0[1]] = this.sc[vt0[0] - 1][vt0[1]];
                this.sc[vt0[0] - 1][vt0[1]] = 0;
            }
        }
        public bool isEx(tacidh2 tc)
        {
            if (this.dif(tc) > 0) return true;
            return false;

        }
        public List<string> getGo()
        {
            int[] vt0 = fL0();
            List<string> k = new List<string>();
            if (vt0[0] == -1) return k;
            k.Add(at[0]);
            k.Add(at[1]);
            k.Add(at[2]);
            k.Add(at[3]);
            if (vt0[0] == 0)
                k.Remove(at[3]);
            if (vt0[0] == this.sc.Count - 1)
                k.Remove(at[2]);
            if (vt0[1] == 0)
                k.Remove(at[1]);
            if (vt0[1] == this.sc[0].Count - 1)
                k.Remove(at[0]);
            return k;

        }
        public int[] fL0()
        {
            int[] k = new int[2];
            k[0] = -1;
            for (int i = 0; i < this.sc.Count; i++)
            {
                for (int j = 0; j < this.sc[i].Count; j++)
                {
                    if (this.sc[i][j] == 0)
                    {
                        k[0] = i;
                        k[1] = j;
                        return k;
                    }
                }
            }
            return k;
        }
        public void loi()
        {
            MessageBox.Show("Loi");
        }
        public string getN(string atg)
        {
            int[] vt0 = fL0();
            if (atg == at[2])
                return this.sc[vt0[0] + 1][vt0[1]].ToString();
            if (atg == at[3])
                return this.sc[vt0[0] - 1][vt0[1]].ToString();
            if (atg == at[0])
                return this.sc[vt0[0]][vt0[1] + 1].ToString();
            if (atg == at[1])
                return this.sc[vt0[0]][vt0[1] - 1].ToString();
            return null;

        }

    }

}



