/*
 * Creado por SharpDevelop.
 * Usuario: JESH
 * Fecha: 06/03/2020
 * Hora: 07:59 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Collections;

//using System.Threading;


namespace ACTIVIDAD2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Bitmap bitm,btmC;
		List <Circle>LP;
		Graph g;
		List<Edge>KL, PL;
		Image imagen;
		int ban=0;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}	
		void Agregar_imaenClick(object sender, EventArgs e) 
		{
			ban=0;
			//Agregar_imaenClick.BackColor = State_Clicked;
			openFileDialog1.ShowDialog();
			Image img = Image.FromFile(openFileDialog1.FileName);
			pictureBox1.Image = img;
			textBox1.Text="";
			textBoxH.Text="";
			
			Bitmap btm = new Bitmap(openFileDialog1.FileName);
			bitm = new Bitmap(openFileDialog1.FileName);
			LP = new List<Circle>();
			int cont=0;
			
			for(int y=0; y<bitm.Height;y++){
				for(int x=0; x<bitm.Width; x++)
				{
					Color c= btm.GetPixel(x,y);
					if(c.R!=255)
						if(c.G !=255)
							if(c.B !=255)
								if(c.R != 100)
									if(c.G != 100)
										if(c.B != 200)
							{
								Circle p = findCenter(x,y,btm);
								if(p.getX() != -1)
								{
									LP.Add(p);
									cont++;
								}
							}
				}
			}
			pictureBox1.Image =  btm;
/**/		g = new Graph(bitm,LP, pictureBox1);
			g.findConection();
			g.printVertexBox(textBox1);
			pictureBox1.Image = bitm;
			btmC=new Bitmap(bitm);

			KL= g.goToFindKruskal(textBoxH);
			drawEdgeList(KL,1);
			bitm.Dispose();
			bitm = new Bitmap(btmC);
			
		}
		
		Circle findCenter(int x,int y,Bitmap btm)
		{
			//Circle cir = new Circle();
			int xx,yy;
//centro
				for(xx = x;xx<btm.Width;xx++)
				{
					Color c = btm.GetPixel(xx,y);
					//c = btm.GetPixel(xx,y);
					if(c.R ==255)
						if(c.G ==255)
							if(c.B ==255)
								break;
				}
				xx--;
				float x_ar = (xx - x)/2;
				float xc = x+x_ar;
				for(yy =y;yy<btm.Height;yy++)
				{
					Color c = btm.GetPixel((int)Math.Round(xc),yy);
					if(c.R ==255)
						if(c.G ==255)
							if(c.B ==255)
								break;
				}
				yy--;
				float ym = (yy - y)/2;
				float yc = y+ym;
				
				int x_ce = (int)Math.Round(xc);
				int y_ce = (int)Math.Round(yc);
				Color co = btm.GetPixel(x_ce,y_ce);
				
				if(co.R ==0)
					if(co.G ==0)
						if(co.B==0)
//radio
				{
				int x1,x2;
		//-x
				for(x1=(int)Math.Round(xc);x1<btm.Width;x1--)
				{
					if(x1<0)
						break;
					Color c = btm.GetPixel(x1,(int)Math.Round(yc));
					if(c.R ==255)
						if(c.G ==255)
							if(c.B ==255)
								break;
				}
				x1++;
		//+x
				for(x2=(int)Math.Round(xc);x2<btm.Width;x2++)
				{
					Color c = btm.GetPixel(x2,(int)Math.Round(yc));
					if(c.R ==255)
						if(c.G ==255)
							if(c.B ==255)
								break;
				}
				x2--;
				float xt = xc-x1;
				float xtt = x2-xc;
				
				int xd = (int)Math.Round(xt+xtt);
				int yd = yy-y;	
				
				float r;
				ym = (int)Math.Round(ym);
				r = xt;
				if(xtt>xt)
					r=xtt;
				if(ym>r)
					r = ym;
				
				int rad = (int)Math.Round(r);
				
				if(xd-yd<11 && xd-yd >-11)
				{
					paintCircle(x_ce,y_ce,btm);
					return new Circle(x_ce,y_ce,rad+3);
				}
				//else
				return new Circle(-1,-1,-1);
				
				}
					return new Circle(-1,-1,-1);
				
			}
		void paintCircle(int x, int y,Bitmap btm)
		{
				Color c1 = btm.GetPixel(x,y);

				for(int y1=y;y1<btm.Height;y1++)
				{
					if(y1<0)
						break;
					c1 = btm.GetPixel(x,y1);
					int x1,x2;
					
					if(c1.R ==255)
						if(c1.G ==255)
							if(c1.B ==255)
								break;
					for(x1=x;x1<btm.Width;x1++)
					{
						c1 = btm.GetPixel(x1,y1);
						if(c1.R ==255)
							if(c1.G ==255)
								if(c1.B ==255)
									break;
						btm.SetPixel(x1,y1,Color.FromArgb(100,100,200));
					}
					for(x2=x-1;x2<btm.Width;x2--)
					{
						if(x2<0)
							break;
						c1 = btm.GetPixel(x2,y1);
						if(c1.R ==255)
							if(c1.G ==255)
								if(c1.B ==255)
									break;
						btm.SetPixel(x2,y1,Color.FromArgb(100,100,200));
						
					}
				}
				//while(true)   y-
				for(int y2=y-1;y2<btm.Height;y2--)
				{
					if(y2<0)
						break;
					c1 = btm.GetPixel(x,y2);
					int x1=x-1,x2=x;
					if(c1.R ==255)
						if(c1.G ==255)
							if(c1.B ==255)
								break;
					for(x1=x;x1<btm.Width;x1++)
					{
						c1 = btm.GetPixel(x1,y2);
						if(c1.R ==255)
							break;
						if(c1.G ==255)
							break;
						if(c1.B ==255)
							break;
						btm.SetPixel(x1,y2,Color.FromArgb(100,100,200));
					}
					for(x2=x-1;x2<btm.Width;x2--)
					{
						if(x2<0)
							break;
						c1 = btm.GetPixel(x2,y2);
						if(c1.R ==255)
							break;
						if(c1.G ==255)
							break;
						if(c1.B ==255)
							break;
						btm.SetPixel(x2,y2,Color.FromArgb(100,100,200));
					}
				}
				pictureBox1.Image = btm;
			}
		public List<Point> makeLine(Circle O, Circle F){
			
			List<Point> line = new List<Point>();
			float m;
			m = ((float)(F.getY()-O.getY())/(float)(F.getX()-O.getX()));
			float b = (O.getY()-m*O.getX());
			if(m>=-1 && m<=1)
			{
				if(O.getX()<F.getX())
				{
					for(int x_k = O.getX();x_k<F.getX();x_k++)
					{
						float y_k;
						if(O.getY() == F.getY())
							y_k = O.getY();
						else
							y_k = ( m*x_k +b);
						
						line.Add(new Point(x_k,(int)y_k));
						x_k+=15;
					}
				}
				else
				{
					for(int x_k = O.getX();x_k>F.getX();x_k--)
					{
						float y_k;
						if(O.getY() == F.getY())
							y_k = O.getY();
						else
							y_k = ( m*x_k +b);
						
						line.Add(new Point(x_k,(int)y_k));
						x_k-=15;
					}
				}
			}
			else
			{
				if(O.getY()<F.getY())
				{
					for(int y_k = O.getY();y_k<=F.getY();y_k++)
					{
						float x_k;
						if(O.getX() == F.getX())
							x_k = O.getX();
						else
							x_k = ( y_k-b)/m;
						
						line.Add(new Point((int)x_k,y_k));
						y_k+=15;	
						}
				}
				else
				{
					for(int y_k = O.getY();y_k>F.getY();y_k--)
				{
					float x_k;
					if(O.getX() == F.getX())
						x_k = O.getX();
					else
						x_k = ( y_k-b)/m;
					
						line.Add(new Point((int)x_k,y_k));
						y_k-=15;
					}
				}
			}
			return line;
		}
		void PictureBox1MouseClick(object sender, MouseEventArgs e)
		{
			pictureBox1.Image = bitm;
			btmC=new Bitmap(bitm);
			pictureBox1.Refresh();
			double px = e.X;
			double py = e.Y;
			
			float k = (float)pictureBox1.Width / (float)bitm.Width ;
			float k2= (float)pictureBox1.Height/(float)bitm.Height ;
			
			if(k2<k)
				k=k2;
			
			double dx = (pictureBox1.Width - (k*bitm.Width))/2;
			double dy = (pictureBox1.Height- (k*bitm.Height))/2;
			int bx = (int)Math.Round((px - dx)/k);
			int by = (int)Math.Round((py - dy)/k);//
			
			Vertex ver = (g.belongs(bx,by));
			if(ver != null)
			{
				PL = g.goToFindPrim(ver,textBoxP);
				drawEdgeList(PL,2);
				
				var radK = new RadioButton();
				var radP = new RadioButton();
				radP = PrimRad;
				radK=KruskalRad;
				
				Bitmap bitmC;
				Graphics grap;
				Bitmap myBitmap = new Bitmap(btmC);
				bitmC = new Bitmap(btmC);
				grap = Graphics.FromImage(bitmC);
				Brush br = new SolidBrush(Color.DarkRed);
				if(ban>0)
				{
					myBitmap.Dispose();
					 myBitmap = new Bitmap(imagen);
					//grap = Graphics.FromImage(myBitmap);
					 
				}
				
				
				List<Edge> some = null;
				var enEspera = new List<Particle>();
				pictureBox1.Image = bitm;
				
				if(radK.Checked)
				{
					some = new List<Edge>(KL);
				}
				if(radP.Checked)
				{
					some = new List<Edge>(PL);
				}
				//INICIO DE RECORRIDO
				if(some != null)
				{	
					int diameter = (int)numericDiameter.Value;
					int div = divideElipse(some,ver);
					while (true)
					{
						Particle pa = existLine(some,ver,diameter,div);
						if(pa==null)
							break;
						else
						{
							if (diameter/div>20)
								enEspera.Add(pa);
						}
					}
					
					while (enEspera.Count>0)
					{
						var bitmap = new Bitmap(bitmC);
						Graphics gr = Graphics.FromImage(bitmap);
						for(int i=0; i<enEspera.Count;i++)
						{
							Particle p = enEspera[i];
							diameter = p.getDiameter();
							
							if (p.walk())
								if(ban==0)
								gr.FillEllipse(br,p.getPosition().X-diameter/2, p.getPosition().Y-diameter/2,
							               diameter, diameter);
								else
								{
									Rectangle compressionRectangle = 
										new Rectangle(p.getPosition().X-diameter/2, p.getPosition().Y-diameter/2,
								               diameter, diameter);
									gr.DrawImage(myBitmap,compressionRectangle);
								}
							else
							{
								div = divideElipse(some,p.getEdge().getVertexD());
								if (div>0)
								{
									int newDiameter = diameter/div;
									
									if (newDiameter>20)
									{
										while (true)
										{
											Particle pa = existLine(some,p.getEdge().getVertexD(),diameter,div);
											if(pa==null)
												break;
											else
												enEspera.Add(pa);
										}
									}
									enEspera.RemoveAt(i);
									i--;
								}
								else{
									if(ban==0)
										grap.FillEllipse(br,p.getPosition().X-diameter/2, p.getPosition().Y-diameter/2,
								               diameter, diameter);
									else
									{
										Rectangle compressionRectangle = 
											new Rectangle(p.getPosition().X-diameter/2, p.getPosition().Y-diameter/2,
											              diameter, diameter);
										grap.DrawImage(myBitmap,compressionRectangle);
									}
									enEspera.RemoveAt(i);
									i--;
								}
							}
							
						}
						Thread.Sleep(1);
						pictureBox1.Image=bitmap;
						pictureBox1.Refresh();
						bitmap.Dispose();
						//myBit.Dispose();
				}
					pictureBox1.Image=bitmC;
					pictureBox1.Refresh();
			}
			}
		}
		void drawEdgeList(List<Edge>L,int op)
		{
			Graphics gra = Graphics.FromImage(btmC);
			Pen pluma = new Pen(Color.FromArgb(100,100,200));
			if(op == 1)//KRUSKAL
				pluma = new Pen(Color.LightGreen,8);
			if (op == 2)//PRIM
				pluma = new Pen(Color.DeepPink,2);
				
			for(int i=0;i<L.Count;i++)
			{
				gra.DrawLine(pluma,L[i].getVertexO().getCircle().getX(),L[i].getVertexO().getCircle().getY(),
				             L[i].getVertexD().getCircle().getX(),L[i].getVertexD().getCircle().getY());
				
			}
			//pictureBox1.Image = bitm;
			pictureBox1.Refresh();
			
		}
		void NumericDiameterValueChanged(object sender, EventArgs e)
		{
			
			var bitmap = new Bitmap(bitm);
			Graphics g = Graphics.FromImage(bitmap);
			
					
			if(ban >0)
			{
			Bitmap myBitmap = new Bitmap(imagen);
				
				/*TextureBrush tBrush = new TextureBrush(imagen);
				g.FillEllipse(tBrush,
        	              bitm.Width/2-(int)numericDiameter.Value/2,
        	              bitm.Height /2-(int)numericDiameter.Value/2,
        	              (int)numericDiameter.Value,
        	              (int)numericDiameter.Value);*/
				Rectangle compressionRectangle = new Rectangle(bitm.Width/2-(int)numericDiameter.Value/2,
			                                               bitm.Width/2-(int)numericDiameter.Value/2,
			                                               (int)numericDiameter.Value,
        	              									(int)numericDiameter.Value);
				g.DrawImage(myBitmap,compressionRectangle);
			}
			else 
			{
        		Brush Brush = new SolidBrush(Color.DarkRed);
        		g.FillEllipse(Brush,
        	              bitm.Width/2-(int)numericDiameter.Value/2,
        	              bitm.Height /2-(int)numericDiameter.Value/2,
        	              (int)numericDiameter.Value,
        	              (int)numericDiameter.Value);
				
			}
			//Pen blackPen = new Pen(Color.Black);
			
			
        	
        	pictureBox1.Image = bitmap;
			pictureBox1.Refresh();
			//ban=0;
		}
		int divideElipse(List<Edge>some, Vertex ver)
		{
			int cont=0;
			for(int i=0;i<some.Count;i++)
			{
				if(some[i].getVertexD()==ver)
					cont++;
				if(some[i].getVertexO()==ver)
					cont++;
			}
			return cont;
		}
		Particle existLine(List<Edge>some, Vertex ver,int diameter, int divide)
		{
			Particle pa = null;
			Edge ed;
			for(int i=0; i<some.Count;i++)
			{
				if(some[i].getVertexD()==ver)
				{
					List<Point>li = makeLine(ver.getCircle(),some[i].getVertexO().getCircle());
					ed = new Edge(some[i].getVertexO(),some[i].getW(),ver);
					pa= new Particle(li,diameter/divide,ed);
					
					some.RemoveAt(i);
					return pa;

				}
				if(some[i].getVertexO()==ver)
				{
					List<Point>li = makeLine(ver.getCircle(),some[i].getVertexD().getCircle());
					ed = new Edge(some[i].getVertexD(),some[i].getW(),ver);
					pa = new Particle(li,diameter/divide,some[i]);
					
					some.RemoveAt(i);
					return pa;
				}
					
			}
			return pa;
		}
		void ImageParticleButtonClick(object sender, EventArgs e)
		{
			openFileDialog2.ShowDialog();
			imagen = Image.FromFile(openFileDialog2.FileName);
			ban=1;
		}
	}		
	public class Circle
	{
		int r;
		int x;
		int y;
		//int id;
		public Circle(int x, int y, int r/*,int id*/)
		{
			this.r = r;
			this.x = x;
			this.y = y;
			//this.id=id;
		}
		public int getX()
		{
			return x;
		}
		public int getY()
		{
			return y;
		}
		public int getR()
		{
			return r;
		}
		public bool pixelInCircle(int x, int y,Circle cir)
		{
			int a,b;
			//if (x<cir.x)
			a = Math.Abs(cir.x - x)+1;
			b = Math.Abs(cir.y - y)+2;
			int c = (cir.r)+4;
			if ((a*a)+(b*b)-(c*c)<=0)
				return true;
			return false;
		}
	}
		
	public class Graph
	{
		
		protected List<Vertex>VL;
		Bitmap bitgra;
		PictureBox pictureBox1;
		
		List<KeyValuePair<Edge,Edge>>PE = new List<KeyValuePair<Edge,Edge>>();
		
		public Graph(Bitmap bitgra,List<Circle>CL, PictureBox pictureBox1)
		{
			this.bitgra = bitgra;
			this.pictureBox1 = pictureBox1;
			VL = new List<Vertex>();
			
			foreach (Circle ci in CL){
				Vertex v = new Vertex(ci,VL.Count+1);
				VL.Add(v);
			}
		}
		public void findConection()
		{
			Graphics gra = Graphics.FromImage(bitgra);
			Pen pluma = new Pen(Color.FromArgb(100,100,200));
			for(int i=0; i<VL.Count; i++)
			{				
				for(int j = i+1;j<VL.Count;j++)
				{
					Circle cir = VL[i].getCircle();
					Circle circl = VL[j].getCircle();
					float prp = inGraphConection(cir,circl);
					if(prp>=0)
						{
							gra.DrawLine(pluma,cir.getX(),cir.getY(),circl.getX(),circl.getY());
							Vertex v= new Vertex(cir,i);
							Edge ed = new Edge(VL[j],prp,VL[i]);
							Edge edg = new Edge(VL[i],prp,VL[j]);
							
							PE.Add(new KeyValuePair<Edge,Edge>(ed,edg));
							
							VL[i].addEdge(ed);
							VL[j].addEdge(edg);
							pictureBox1.Image = bitgra;				
					}
					
			}
			}
			
		}
		float inGraphConection(Circle O, Circle F)
		{
			float m;
			int q;
			m = ((float)(F.getY()-O.getY())/(float)(F.getX()-O.getX()));//10
			float b = (O.getY()-m*O.getX());//5
			if(m>=-1 && m<=1)//4
			{
				if(O.getX()<F.getX())//3
				{
					q=O.getX();//2
					for(int x_k = O.getX();x_k<F.getX();x_k++)//2+
					{
						float y_k;
						if(O.getY() == F.getY())
							y_k = O.getY();
						else
							y_k = ( m*x_k +b);
						if(q!=x_k)
						{
							q=x_k;
							x_k-=1;
						}
						
						Color c = bitgra.GetPixel((x_k),(int)Math.Round(y_k));
						
					if(c.R == 255 && c.G == 255 && c.B == 255){
						}
						else if(c.R != 100)
							if(c.G != 100)
								if(c.B != 200)
									if(!O.pixelInCircle(x_k,(int)y_k,O))
										if(!O.pixelInCircle(x_k,(int)y_k,F))
																		return -1;
					}
					float z1 = (F.getX()-O.getX());
					float z2 = (F.getY()-O.getY());
					return((float)Math.Sqrt((z1*z1)+(z2*z2)));
				}
				else
				{
					q=O.getX();
					for(int x_k = F.getX();x_k<O.getX();x_k++)
					{
						float y_k;
						if(O.getY() == F.getY())
							y_k = O.getY();
						else
							y_k = ( m*x_k +b);
						
						if(q!=x_k)
						{
							q=x_k;
							x_k-=1;
						}
						
						Color c = bitgra.GetPixel((x_k),(int)Math.Round(y_k));
						if(c.R == 255 && c.G == 255 && c.B == 255){
						}
						else if(c.R != 100)
							if(c.G != 100)
								if(c.B != 200)
									if(!O.pixelInCircle(x_k,(int)y_k,F))
														if(!O.pixelInCircle(x_k,(int)y_k,O))
															return -1;
						
					}
					float z1 = (F.getX()-O.getX());
					float z2 = (F.getY()-O.getY());
					return((float)Math.Sqrt((z1*z1)+(z2*z2)));
				}
			}
			else
			{
				if(O.getY()<F.getY())
				{
					q=O.getY();
					
					for(int y_k = O.getY();y_k<=F.getY();y_k++)
					{
						float x_k;
						if(O.getX() == F.getX())
							x_k = O.getX();
						else
							x_k = ( y_k-b)/m;
						
						if(q!=y_k)
						{
							q=y_k;
							y_k-=1;
						}
							
						
						Color c = bitgra.GetPixel((int)Math.Round(x_k),(y_k));
						if(c.R == 255 && c.G == 255 && c.B == 255){
						}
						else if(c.R != 100)
							if(c.G != 100)
								if(c.B != 200)
									if(!O.pixelInCircle((int)x_k,y_k,F))
										if(!O.pixelInCircle((int)x_k,y_k,O))
										
														return -1;
						}
					float z1 = (F.getX()-O.getX());
					float z2 = (F.getY()-O.getY());
					return((float)Math.Sqrt((z1*z1)+(z2*z2)));
				}
				else
				{
					q=O.getY();
					
					for(int y_k = F.getY();y_k<=O.getY();y_k++)
				{
					float x_k;
					if(O.getX() == F.getX())
						x_k = O.getX();
					else
						x_k = ( y_k-b)/m;
					
					if(q!=y_k){
						q=y_k;
						y_k-=1;
					}
					
					Color c = bitgra.GetPixel((int)Math.Round(x_k),(y_k));
					if(c.R == 255 && c.G == 255 && c.B == 255){
						}
						else if(c.R != 100)
							if(c.G != 100)
								if(c.B != 200)
									if(!O.pixelInCircle((int)x_k,y_k,O))				
										if(!O.pixelInCircle((int)x_k,y_k,F))
											return -1;
						
					}
					float z1 = (F.getX()-O.getX());
					float z2 = (F.getY()-O.getY());
					return((float)Math.Sqrt((z1*z1)+(z2*z2)));
				}
			}
		}
		
		public void printVertexBox(TextBox vertexbox)
		{
			Graphics gra = Graphics.FromImage(bitgra);
			
			Brush bru = new SolidBrush(Color.Orange);
			vertexbox.Text = "**CLOSEST PAIR POITS COLOR AQUA**\r\nCONECCIONES\r\n";
			for(int i = 0;i<VL.Count;i++)
			{
				Font font = new Font(FontFamily.GenericSansSerif,VL[i].getCircle().getR(),FontStyle.Bold,GraphicsUnit.Pixel);
				VL[i].printEdge(vertexbox,VL[i]);
				vertexbox.Text +="\r\n";
				gra.DrawString((i+1).ToString(),font,bru,VL[i].getCircle().getX(),VL[i].getCircle().getY());
			}
		}
		public Vertex belongs(int x, int y)/**/
		{
			for(int i = 0; i<VL.Count;i++)
			{
				if ((y - VL[i].getCircle().getY())*(y - VL[i].getCircle().getY())+ 
				    (x - VL[i].getCircle().getX())*(x - VL[i].getCircle().getX())-
				    (VL[i].getCircle().getR())*(VL[i].getCircle().getR()) <=0  )
					return VL[i];
			}
			return null;
		}
		public List<Edge> goToFindPrim(Vertex v,TextBox tb)
		{
			Vertex ve = new Vertex(null,0);
			List<Edge>pl =new List<Edge>();
			pl = ve.findPrim(v,VL,PE,tb);
			return pl;
		}
		public List<Edge> goToFindKruskal(TextBox tb)
		{
			Vertex ve = new Vertex(null, 0);
			List<Edge>pl =new List<Edge>();
			pl = ve.findKruskal(VL,PE,tb);
			return pl;
		}
		
	}
		
	public class Vertex 
	{
		Circle data;
		int id;
		List<Edge>EL;
		
		public Vertex(Circle data,int id)
		{
			EL = new List<Edge>();
			this.data=data;
			this.id=id;
		}
		public void addEdge(Edge ed)
		{
			EL.Add(ed);
		}
		public Circle getCircle()
		{
			return data;
		}
		public int getID()
		{
			return id;
		}
		
		public void printEdge(TextBox text, Vertex v)
		{
			text.Text += "["+v.getID()+"] => ";
			for(int i = 0;i<EL.Count;i++)
				{
				text.Text += "["+EL[i].getVertexD().getID()+", ("+EL[i].getW()+")]";
				}	
		}
		
		public List<Edge> findPrim(Vertex v, List<Vertex>VL,List<KeyValuePair<Edge,Edge>>EdL,TextBox tb)
		{
			tb.Text = "PRIM (rosa)\r\n";
			var pe = new List<KeyValuePair<Edge,Edge>>(EdL);  //lista con aristas dobles
	
			List<Edge>prometedor = new List<Edge>();
			List<Edge>candidatos = new List<Edge>();
			var padre = new List<Vertex>(VL);
			Edge act;
			Vertex actual = v;
			float total=0;
			//7+
			while(prometedor.Count != VL.Count-1)//4+
			{
				for(int i=0;i<pe.Count;i++)//3+18n
				{
					if (pe[i].Key.getVertexO()==actual)
					{
						candidatos.Add(pe[i].Key);
					}
					else if (pe[i].Key.getVertexD()==actual)
					{
						candidatos.Add(pe[i].Value);
					}
				}
				//seleccion candidato
				//buscar el menor entre aristas
				int cProm=0;
				act=null;
				//2+
				for(int j=0;j<candidatos.Count;j++)//3+16--19
				{									//3+19n
					if (act == null)
						if(!sameParent(candidatos[j].getVertexO().getID(),candidatos[j].getVertexD().getID(),padre))
						{
								act=candidatos[j];
								cProm=j;
						}
						else 
						{
							candidatos.RemoveAt(j);
							j--;
						}
					
					else if(candidatos[j].getW()<act.getW())
						if(!sameParent(candidatos[j].getVertexO().getID(),candidatos[j].getVertexD().getID(),padre))//**
							{
								act=candidatos[j];
								cProm=j;
							}
				}
				if (act==null)
					break;
				tb.Text += "["+act.getVertexD().getID()+"-> ["+act.getVertexO().getID()+"] ("+act.getW()+")\r\n";
				//15+12
				total+= act.getW();
				Union(act.getVertexD().getID(),act.getVertexO().getID(),padre);//**+
				actual = act.getVertexD();
				prometedor.Add(act);
				candidatos.RemoveAt(cProm);
				//termino seleccion
			}
			tb.Text+="TOTAL: "+total;
			
			return prometedor;
				
		}
		public List<Edge> findKruskal(List<Vertex>VL, List<KeyValuePair<Edge,Edge>>EdL,TextBox tb)
		{
			tb.Text = "KRUSKAL (verde)\r\n";
			var pe = new List<KeyValuePair<Edge,Edge>>(EdL);  //lista con aristas dobles
			var prometedor = new List<Edge>();
			Edge mej = null;
			int cont = 0;
			float total=0;
			var padre = new List<Vertex>(VL);
			while(prometedor.Count!=VL.Count-1)
			{
				for(int i=0;i<pe.Count;i++)
				{
					if (!sameParent(pe[i].Key.getVertexO().getID(),pe[i].Key.getVertexD().getID(),padre))
					{
						if (mej==null)
							mej = pe[i].Key;
						if (pe[i].Key.getW() < mej.getW())
						{
							mej=pe[i].Key;
							cont=i;
						}
					}
				}
				if (mej==null)
					break;
				tb.Text += "["+mej.getVertexD().getID()+"-> ["+mej.getVertexO().getID()+"] ("+mej.getW()+")\r\n";
				total+= mej.getW();
				Union(mej.getVertexD().getID(),mej.getVertexO().getID(),padre);
				prometedor.Add(mej);
				pe.RemoveAt(cont);
				cont=0;
				mej=null;
				
			}	
			tb.Text+= "TOTAL: "+total;
			return prometedor;
		}
		bool factible(List<Edge>aristas, Edge comparar)
		{
			Vertex O = comparar.getVertexO();
			Vertex D = comparar.getVertexD();
			for(int i=0;i<aristas.Count;i++)
			{
				if(D== aristas[i].getVertexO())
				{
					if(O== aristas[i].getVertexD())
						return false;
				}
				if(D== aristas[i].getVertexD())
				{
					if(O== aristas[i].getVertexO())
						return false;
				}
				
			}
			return true;
		}
		Vertex Find( int x,List<Vertex>padre ){ // x es el id del, vertice
			return ( x == padre[ x-1 ].getID() ) ? padre[ x-1 ] : padre[ x-1 ] = Find( padre[ x-1 ].getID(),padre );
		}
		void Union( int x , int y,List<Vertex>padre ){
			padre[Find( x,padre).getID()-1] = Find(y,padre);
		}
		bool sameParent( int x , int y, List<Vertex>padre){
			return Find( x,padre ) == Find( y,padre );
		}
	}
	
	public class Edge
	{
		Vertex d;
		float w;
		Vertex o;
		public Edge(Vertex d, float w,Vertex o)
		{
			this.d=d;
			this.w=w;
			this.o = o;
		}
		public Vertex getVertexD()
		{
			return d;
		}
		public Vertex getVertexO()
		{
			return o;
		}
		public float getW()
		{
			return w;
		}
	}
	public class Particle
	{
		List<Point> line;
		int actualIndex;
		int diameter;
		Edge ed;
		
		public Particle(List<Point> l, int d,Edge arista)
		{
			line = l;
			actualIndex = 0;
			diameter = d;
			ed = arista;
		}
		
		public bool walk(){
			if (actualIndex+1 < line.Count){
				actualIndex += 1;
				return true;
			}
			else{
				actualIndex =  line.Count-1;
				return false;
			}
		}
		
		public void setNewPath(List<Point> l){
			actualIndex = 0;
			line = l;
		}
		
		public Point getPosition(){
			return new Point(line[actualIndex].X, line[actualIndex].Y);
		}
		
		public Point getPenultimate(){
			return line[line.Count-2];
		}
		
		public void setDiameter(int d){
			diameter = d;
		}
		public int getDiameter(){
			return diameter;
		}
		public Edge getEdge()
		{
			return ed;
		}
	}
	
	}

