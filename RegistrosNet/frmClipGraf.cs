using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices ;
using System.IO;

namespace RegistrosNet
{
    public partial class frmClipGraf : Form
    {
        /// <summary>
        /// La aplicación se basa en teclas y en uso del mouse para marcar flechas y textos
        /// prescinde de botones y otros objetos gráficos
        /// la idea es, capturar pantalla con Print Screen y con el foco en este formulario, con Insert se 
        /// ingresa la imagen, al pulsar enter se cropea al tamaño del formulario, para ingresar otra se repite el proceso
        /// ubicándose debajo de la primera, antes se puede acomodar en el caso de que la imagen sea de dos monitores, se puede
        /// elegir que area se va a restringir, además se puede solapar con la anterior, subiéndola , agregar flechas y
        /// explicaciones siempre sobre la última 
        /// Con el ingresado de cada imagen, se debe confirmar con Enter para cropear y resetear todos los objetos de la
        /// version que se plasman con cada evento Paint , la idea es que con F3 se vuelve a una imagen anterior al último
        /// agregado de flechas y con F4 al agregado de textos, con Del se borra toda la última imagen y resetean los 
        /// cambios, con Escape se borran todas las imagenes
        /// Con F1 se construye una imagen única que engloba a las imagenes con sus respectivas alturas y se salva a una locacion
        /// preestablecida, si el archivo ya existía, se le agregan números de dos cifras a modo de versionado automaticamente
        /// sin aviso de preexistencia de archivo
        /// La sobrecarga del constructor está para poder fusionarse con la solución Regx y pasarle una ruta preestablecida
        /// donde salvar la ímagen construida
        /// </summary>
        public frmClipGraf()
        {
            InitializeComponent();
            arriba = new Point(0,0);
            PosicionVisual = this.Height;
            AjustoAlAnchoPantalla();
            r = new Rectangle(0, 0, 20, 20);
            IngresarImagenAFormulario();
            ActualizarInfoImagenes(" ÚLTIMA NO CONFIRMADA");
        }

        public frmClipGraf(string rutaSalvado)
        {
            InitializeComponent();
            arriba = new Point(0, 0);
            PosicionVisual = this.Height;
            r = new Rectangle(0, 0, 20, 20);
            AjustoAlAnchoPantalla();
            this._rutaDefecto = rutaSalvado;
            IngresarImagenAFormulario();
            ActualizarInfoImagenes(" ÚLTIMA NO CONFIRMADA");

        }
        

        #region VARIABLES_ENUMERADORES_Y_PREOBJETOS
        public string _rutaDefecto = "";
        Rectangle r;
        int AlturaAcumulada = 0;
        int NumeroImagen = 0;
        int NumeroImagenAnterior = -1;
        int CorrimientoHorizontalAcumulado = 0;
        int CorrimientoVerticalAcumulado = 0;
        int PosicionVisual = 0;
        public string rutaEstablecida = "";
        int XiniMouse = 0;
        int YiniMonse = 0;
        int XfinMouse = 0;
        int YfinMouse = 0;
        bool primerCoordenadaCargada = false;
        Point arriba;
        List<CoorLinea> listaLineas = new List<CoorLinea>();
        List<Textos> listaTextos = new List<Textos>();
        public string TRANSFERENCIA_TEXTO;
        public string NombreArchivoASalvar;

        float alturaLetra = 15f;

        List<acciones> versionadoAcciones = new List<acciones>();
        enum acciones
        {
            NuevaLinea,
            NuevoTexto,
            NuevaImagen
        }
        List<Image> versionadoImagenes = new List<Image>();
        int anchoLinea = 10;

        #endregion

        private void AjustoAlAnchoPantalla()
        {
            Rectangle rectanguloPantalla = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            int anchoPantalla = rectanguloPantalla.Width;
            this.Width = anchoPantalla;
        }
        private void Tope()
        {
            this.AutoScrollPosition = arriba;
        }

        /// <summary>
        /// Toma solamente un objeto imágen desde el clipboard, le asigna tres eventos, lo ingresa a un picturebox
        /// lo guarda en la lista de versionados ( para poder deshacer agregados de flechas y escritos ) y lo agrega
        /// como control al formulario, luego posiciona el cursor al final de su altura
        /// El versionado de acciones está en prototipo , no se usa
        /// </summary>
        /// <returns></returns>
        private Image IngresarImagenAFormulario()
        {
            Image imCapturada = Clipboard.GetImage();
            if (imCapturada != null)
            {
                versionadoImagenes.Add((Image)imCapturada.Clone());
                versionadoAcciones.Clear();
                listaLineas.Clear();
                listaTextos.Clear();
                PictureBox pic = new PictureBox();
                pic.Width = imCapturada.Width;
                pic.Height = imCapturada.Height;
                pic.Image = imCapturada;
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Left = 0;
                NumeroImagen++;
                NumeroImagenAnterior++;
                pic.Name = NumeroImagen.ToString();
                pic.MouseDoubleClick += new MouseEventHandler(pic_MouseDoubleClick);
                pic.MouseMove += new MouseEventHandler(pic_MouseMove);

                pic.Paint += new PaintEventHandler(pic_Paint);
                this.Controls.Add(pic);
                pic.BringToFront();
                Tope();
                
                MoverPicturebox(pic, 0, AlturaAcumulada);
                AlturaAcumulada = AlturaAcumulada + pic.Height;
                this.AutoScrollPosition = new Point(0, AlturaAcumulada  );
                versionadoAcciones.Add(acciones.NuevaImagen);
                
            }
            return imCapturada;
        }

        /// <summary>
        /// Este evento detecta, si se pulsó boton iz del mouse dos veces, se crea la primer y luego segunda coordenada
        /// para crear flechas
        /// Si se pulsó dos veces el boton der del mouse dos veces, se fija la coordenada para un escrito, una vez transferido
        /// el contenido desde frmInputBox a la variable TRANSFERENCIA_TEXTO, se continua con el metodo DibujarTexto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                XiniMouse = e.X;
                YiniMonse = e.Y;
                frmInputBox inp = new frmInputBox(this);
                inp.Show();

            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (primerCoordenadaCargada)
                {
                    XfinMouse = e.X;
                    YfinMouse = e.Y;

                    DibujarLinea(XiniMouse, YiniMonse, XfinMouse, YfinMouse, sender);
                    XiniMouse = 0;
                    YiniMonse = 0;
                    primerCoordenadaCargada = false;
                }
                else
                {
                    XiniMouse = e.X;
                    YiniMonse = e.Y;
                    primerCoordenadaCargada = true;


                }
            }            
   
        }


        /// <summary>
        /// Evento que permite , una vez tenida la primer coordenada desde el doble click del mouse, redibujar con 
        /// cada movimiento del mouse , la punta final de la flecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender != null && XiniMouse > 0 && YiniMonse > 0)
            {
                PictureBox p = DevuelvoPorNombre(NumeroImagen.ToString());
                p.Capture = true;

                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255), anchoLinea);
                pen.StartCap = LineCap.NoAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                p.Refresh();
                p.CreateGraphics().DrawLine(pen, XiniMouse, YiniMonse, e.X, e.Y);

                
            }
        }

        /// <summary>
        /// Evento que se vale de las dos listas, las de flechas y las de textos para redibujar cada vez que se
        /// renderice la imágen en pantalla, la lista de objetos existentes sobre las imágenes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void pic_Paint(object sender, PaintEventArgs e)
        {
            if (sender != null && sender is PictureBox )
            {
                PictureBox p = (PictureBox)sender;
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255), anchoLinea);
                pen.StartCap = LineCap.NoAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                Font letra = new System.Drawing.Font(FontFamily.GenericSansSerif, alturaLetra);
                foreach (CoorLinea c in listaLineas)
                {
                    p.Capture = true;
                    Graphics l = p.CreateGraphics();
                    l.DrawLine(pen, c.xIni, c.yIni, c.xFin, c.yFin);

                    l.Flush();
                    l.Dispose();
                }


                foreach (Textos t in listaTextos)
                {
                    p.Capture = true;
                    Graphics l = p.CreateGraphics();
                    l.DrawString(t.contenido, letra, Brushes.Black, new Point(t.xIni, t.yIni));
                    l.Flush();
                    l.Dispose();
                }
                pen.Dispose();
                letra.Dispose();

            }
        }


        /// <summary>
        /// Valiéndose de las coordenadas iniciales y tomando el resultado de frmInputBox, plasma el texto
        /// sobre el último picturebox, llamando al evento Paint
        /// </summary>
        public void DibujarTexto()
        {
            PictureBox e = DevuelvoPorNombre(NumeroImagen.ToString());
            e.Capture = true;
            versionadoImagenes.Add((Image) e.Image.Clone());
            Font letra = new System.Drawing.Font(FontFamily.GenericSansSerif, alturaLetra);
            Graphics l = Graphics.FromImage(e.Image);
            l.DrawString(this.TRANSFERENCIA_TEXTO, letra, Brushes.Black, new Point(XiniMouse, YiniMonse));
            
            Textos t = new Textos();
            t.contenido = this.TRANSFERENCIA_TEXTO;
            t.xIni = XiniMouse;
            t.yIni = YiniMonse;
            listaTextos.Add(t);
            XiniMouse = 0;
            YiniMonse = 0;
            versionadoAcciones.Add(acciones.NuevoTexto);

            pic_Paint(e, null);
        }

        /// <summary>
        /// Valiéndose de las coordenadas inicial y final , dibuja una flecha sobre el último picturebox del sender
        /// luego llama al evento Paint
        /// </summary>
        /// <param name="xdesde"></param>
        /// <param name="ydesde"></param>
        /// <param name="xhasta"></param>
        /// <param name="yhasta"></param>
        /// <param name="sender">ùltimo picturebox</param>
        private void DibujarLinea(int xdesde, int ydesde, int xhasta, int yhasta,object sender)
        {
           
            PictureBox e = (PictureBox)sender;
            e.Capture = true;
            versionadoImagenes.Add((Image)e.Image.Clone());
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255), anchoLinea);
            pen.StartCap = LineCap.NoAnchor;
            pen.EndCap = LineCap.ArrowAnchor;

            Graphics l = Graphics.FromImage(e.Image);
            l.DrawLine(pen, xdesde, ydesde, xhasta, yhasta);
            
   
            CoorLinea c = new CoorLinea();
            c.xIni = xdesde;
            c.yIni = ydesde;
            c.xFin = xhasta;
            c.yFin = yhasta;
            listaLineas.Add(c);
            versionadoAcciones.Add(acciones.NuevaLinea);

            pic_Paint(e, null);
        }

        



        /// <summary>
        /// Método que actualiza info sobre el Text del formulario 
        /// </summary>
        private void ActualizarInfoImagenes(string mensaje1)
        {
            this.Text = "Imagenes= " + NumeroImagen.ToString() +  " ancho form= " + this.Width.ToString() + " alto form= " + this.Height .ToString() + " visual = " + PosicionVisual .ToString() + " corrimiento H = " + CorrimientoHorizontalAcumulado.ToString() + " corrimiento V = " + CorrimientoVerticalAcumulado.ToString() + " flechas= " + listaLineas.Count.ToString() + " textos = " + listaTextos.Count.ToString() + " ( " + mensaje1 + " ) " ;
        }

        /// <summary>
        /// Utilidad para encontrar una vez ingresado el control , cual es el último Picturebox porque se
        /// trabajará sobre su imágen
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private PictureBox DevuelvoPorNombre(string nombre)
        {
            PictureBox encontrado = null;
            foreach (Control c in this.Controls)
            {
                PictureBox p = (PictureBox)c;
                if (p.Name == nombre)
                {
                    encontrado = p;
                    break;
                }
            }
            return encontrado;
        }


        private void BorrarUltimoPicture()
        {
            PictureBox p = DevuelvoPorNombre(NumeroImagen.ToString());
            AlturaAcumulada = AlturaAcumulada - p.Height;
            this.Controls.Remove(p);
            NumeroImagen--;
            NumeroImagenAnterior--;
            CorrimientoHorizontalAcumulado = 0;
            CorrimientoVerticalAcumulado = 0;
            listaLineas.Clear();
            listaTextos.Clear();
            versionadoAcciones.Clear();
            versionadoImagenes.Clear();
            PosicionVisual = 0;
            XiniMouse = 0;
            YiniMonse = 0;
            XfinMouse = 0;
            YfinMouse = 0;
            primerCoordenadaCargada = false;


            
        }

        private void BorrarTodo()
        {
            int total = NumeroImagen;
            for (int i = 1; i <= total; i++)
            {
                BorrarUltimoPicture();
            }
            AlturaAcumulada = 0;
            NumeroImagen = -1;
            NumeroImagenAnterior = -1;

        }

        /// <summary>
        /// Este método existe para desplazar el picturebox usando las dimensiones del formulario para poder
        /// cropear la imágen 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ArribaIzX"></param>
        /// <param name="ArribaIzY"></param>
        private void MoverPicturebox(PictureBox p, int ArribaIzX, int ArribaIzY)
        {
            p.Top = ArribaIzY;
            p.Left = ArribaIzX;
        }

        /// <summary>
        /// El CorrimientoHorizontalAcumulado manipula la imágen, el resto es manipulacion del picturebox
        /// </summary>
        private void MoverParaDerecha()
        {
            PictureBox p = DevuelvoPorNombre(NumeroImagen.ToString());
            CorrimientoHorizontalAcumulado -= 20;
            MoverPicturebox(p, 20 + p.Location.X, p.Location.Y);
        }

        /// <summary>
        /// El CorrimientoHorizontalAcumulado manipula la imágen, el resto es manipulacion del picturebox
        /// </summary>
        private void MoverParaIzquierda()
        {
            PictureBox p = DevuelvoPorNombre(NumeroImagen.ToString());
            CorrimientoHorizontalAcumulado += 20;
            MoverPicturebox(p, -20 + p.Location.X, p.Location.Y);
        }



        /// <summary>
        /// Acá se mueve en forma coordinada , el picturebox de modo que se "solape" sobre la imagen anterior
        /// AlturaAcumulada permite restar el solapamiento a la imagen anterior
        /// </summary>
        private void MoverParaArriba()
        {
            PictureBox p = DevuelvoPorNombre(NumeroImagen.ToString());
            MoverPicturebox(p, p.Location.X, -20 + p.Location.Y);
            AlturaAcumulada = AlturaAcumulada - 20;
            CorrimientoVerticalAcumulado = CorrimientoVerticalAcumulado + 20;
        }

        /// <summary>
        /// Acá es donde se le resta del borde inferior a la imagen anterior , la AlturaAcumulada que entra como Corrimiento
        /// De esta forma, la imagen anterior por referencia, al salvarla se arma con la altura final del corrimiento
        /// </summary>
        /// <param name="p"></param>
        /// <param name="corrimiento"></param>
        /// <returns></returns>
        private PictureBox AchicarVerticalmente(PictureBox p, int corrimiento)
        {
            Image i = p.Image;
            Bitmap nueva = new Bitmap(this.Width, i.Height - corrimiento);
            Graphics g = Graphics.FromImage(nueva);

            int ancho = i.Width;
            int alto = i.Height;
            RectangleF origenRect = new RectangleF(0, 0, this.Width, alto - corrimiento);
            RectangleF destinoRect = new RectangleF(0, 0, this.Width, alto - corrimiento);
            g.DrawImage(i, destinoRect, origenRect, GraphicsUnit.Pixel);

            p.Height = nueva.Height;
            p.Image = nueva;

            return p;
        }


        /// <summary>
        /// Esta forma es la contraria al MoverParaArriba y permite descontar del corrimiento a la imagen anterior
        /// afectada en su altura final
        /// </summary>
        private void MoverParaAbajo()
        {
            PictureBox p = DevuelvoPorNombre(NumeroImagen.ToString());
            MoverPicturebox(p, p.Location.X, 20 + p.Location.Y);
            AlturaAcumulada = AlturaAcumulada + 20;
            CorrimientoVerticalAcumulado = CorrimientoVerticalAcumulado - 20;
        }
        


        /// <summary>
        /// Evento capital:
        /// con teclas :
        /// Insert, se agrega nueva imagen
        /// Delete, se borra la inmediatamente última ingresada
        /// Derecha e Izquierda, arriba, Abajo, se mueve la imagen hacia esos lados
        /// Enter, se cropea la imagen luego de moverla hacia los lados requeridos
        /// F1, se componen todas las imágenes en sus pictureboxes ingresados al formulario y se graban como PNG
        /// Pagina Abajo, Pagina Arriba, permite desplazar la visual en pequeños saltos , en esos sentidos
        /// F12, agranda ancho formulario
        /// F11, achica ancho formulario 
        /// F10, agranda ancho formulario
        /// F9, achica ancho formulario
        /// Escape, se elimina todo lo realizado
        /// F3, elimino la version actual de lineas
        /// F4, elimino la version actual de textos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmClipGraf_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert :
                    ConfirmarRedimensionado();
                    IngresarImagenAFormulario();
                    ActualizarInfoImagenes(" ÚLTIMA NO CONFIRMADA");
                    break;
                case Keys.Delete:
                    BorrarUltimoPicture();
                    ActualizarInfoImagenes(" ULTIMA BORRADA ");
                    break;
                case Keys.Right :
                    MoverParaIzquierda();
                    ActualizarInfoImagenes(" CORRIMIENTO A DERECHA ");
                    break;
                case Keys.Left :
                    MoverParaDerecha();
                    ActualizarInfoImagenes(" CORRIMIENTO A IZQUIERDA ");
                    break;
                case Keys.Up:
                    ActualizarInfoImagenes(" CORRIMIENTO HACIA ARRIBA ");
                    if ( NumeroImagen > 1 )
                        MoverParaArriba();
                    else
                        MessageBox.Show("DEBE TENER AL MENOS 2 IMÁGNENES PARA PROCESAR VERTICALEMNTE");
                    break;
                case Keys.Down:
                    MoverParaAbajo();
                    ActualizarInfoImagenes(" CORRIMIENTO HACIA ABAJO ");
                    break;
                case Keys.F1:
                    ConfirmarRedimensionado();
                    SalvarTodasLasImagenes();
                    this.Close();
                    break;
                case Keys.Enter:
                    ConfirmarRedimensionado();
                    PictureBox pcb = DevuelvoPorNombre(NumeroImagen.ToString());
                    ActualizarInfoImagenes("CONFIRMADA LA ÚLTIMA ");
                    pic_Paint(pcb, null);
                    break;
                case Keys.PageUp:
                    PosicionVisual = ( PosicionVisual <= 0? 0 : PosicionVisual - 50 );
                    this.AutoScrollPosition = new Point(0, PosicionVisual);
                    ActualizarInfoImagenes(" DESPLAZAMIENTO VISUAL ARRIBA ");
                    
                    break;
                case Keys.PageDown :
                    PosicionVisual = (PosicionVisual >= AlturaAcumulada ? AlturaAcumulada : PosicionVisual + 50);
                    this.AutoScrollPosition = new Point(0, PosicionVisual);
                    ActualizarInfoImagenes(" DESPLAZAMIENTO VISUAL ABAJO ");
                    break;

                case Keys.F12:
                    this.Width += 20;
                    this.Refresh();
                    ActualizarInfoImagenes(" ENSANCHAR FORMULARIO ");
                    break;
                case Keys.F11:
                    this.Width -= 20;
                    this.Refresh();
                    ActualizarInfoImagenes(" ANGOSTAR FORMULARIO ");
                    break;

                case Keys.F10:
                    this.Height += 20;
                    this.Refresh();
                    ActualizarInfoImagenes(" INCREMENTO ALTURA FORMULARIO ");
                    break;
                case Keys.F9:
                    this.Height -= 20;
                    this.Refresh();
                    ActualizarInfoImagenes(" DECREMENTO ALTURA FORMULARIO ");
                    break;
                case Keys.Escape :
                    BorrarTodo();
                    break;

                case Keys.F3:
                    DeshagoUltimaLinea();
                    ActualizarInfoImagenes(" REVERSADO FLECHAS ");
                    break;
                case Keys.F4:
                    DeshagoUltimoTexto();
                    ActualizarInfoImagenes(" REVERSADO TEXTOS ");
                    break;
                case Keys.Back:

                    break;

            }
        }

        private void DeshagoUltimaLinea()
        {
            if (listaLineas.Count > 0)
            {
                PictureBox e = DevuelvoPorNombre(NumeroImagen.ToString());
                listaLineas.RemoveAt(listaLineas.Count - 1);
                e.Image = versionadoImagenes[versionadoImagenes.Count - 1];
                versionadoImagenes.RemoveAt(versionadoImagenes.Count - 1);
                pic_Paint(e, null);
            }
        }

        private void DeshagoUltimoTexto()
        {
            if (listaTextos.Count > 0)
            {
                PictureBox e = DevuelvoPorNombre(NumeroImagen.ToString());
                listaTextos.RemoveAt(listaTextos.Count - 1);
                e.Image = versionadoImagenes[versionadoImagenes.Count - 1];
                versionadoImagenes.RemoveAt(versionadoImagenes.Count - 1);
                pic_Paint(e, null);
            }
        }

        /// <summary>
        /// Ajuste a "ventana" del formulario
        /// </summary>
        private void ConfirmarRedimensionado()
        {
            PictureBox p = DevuelvoPorNombre(NumeroImagen.ToString());
            p = DesplazarImagen(p, CorrimientoHorizontalAcumulado);
            CorrimientoHorizontalAcumulado = 0;
            if (NumeroImagen > 1)
            {
                AchicarVerticalmente(DevuelvoPorNombre(NumeroImagenAnterior.ToString()), CorrimientoVerticalAcumulado);
                CorrimientoVerticalAcumulado = 0;
            }


        }

        /// <summary>
        /// Ajuste horizontal
        /// </summary>
        /// <param name="p"></param>
        /// <param name="corrimiento"></param>
        /// <returns></returns>
        private PictureBox  DesplazarImagen(PictureBox p, int corrimiento)
        {
            Image i = p.Image;
            Bitmap nueva = new Bitmap(this.Width, i.Height);
            Graphics g = Graphics.FromImage(nueva);
            
            int ancho = i.Width;
            int alto = i.Height;
            RectangleF origenRect = new RectangleF( corrimiento, 0, this.Width, alto);
            RectangleF destinoRect = new RectangleF(0, 0, this.Width, alto);
            g.DrawImage(i, destinoRect, origenRect, GraphicsUnit.Pixel);

            p.Width = nueva.Width;
            p.Image = nueva;
            p.Left = 0;
            return p;
        }



        /// <summary>
        /// Se componen todas las imágenes agregadas al formulario  en su orden correcto, calculando la altura
        /// final para luego armar una imagen compuesta única gigante y luego se permite elegir donde salvarla
        /// </summary>
        private void SalvarTodasLasImagenes()
        {
            int alto = 0;
            int anchoForm = this.Width;
            string nombreCompletoInexistente = "";
            // la lista recopila las imágenes
            List<Image> lista = new List<Image>();
            /// usando el formulario como una colección, extraigo una a una cada imágen
            /// extraigo el alto de cada imágen y la acumulo
            /// invierto el orden de las imágenes
            foreach (Control c in this.Controls)
            {
                PictureBox p = (PictureBox)c;
                Bitmap bit = new Bitmap(p.Image);

                alto = alto + bit.Height;
                lista.Add(bit);
            }
            lista.Reverse();
            /// con la altura general, creo una imágen que albergue a las
            /// demás, itero y apilo cada imagen de la lista
            Bitmap imagenFinal = new Bitmap(anchoForm, alto);
            int offset = 0;
            using (Graphics g = Graphics.FromImage(imagenFinal))
            {
                foreach (Image im in lista)
                {
                    g.DrawImage(im, new Rectangle(0, offset, anchoForm , im.Height));
                    offset += im.Height;
                    g.Save();
                }

            }
            
            if (imagenFinal != null)
            {
                rutaEstablecida = Utilidades.ConsultarRutasRelativas(((frmRegistros)this.Owner).TextoTemas);
                frmElegirRutaParaNombre svd = new frmElegirRutaParaNombre(rutaEstablecida);
                
                svd.ShowDialog(this);
                if (NombreArchivoASalvar != "")
                {
                    string nombre = this.NombreArchivoASalvar + ".png";
                    string nombreSolo = nombre.Substring(nombre.LastIndexOf(@"\") + 1, (nombre.Length - nombre.LastIndexOf(@"\")) - 1);
                    imagenFinal.Save(nombre, ImageFormat.Png);
                    imagenFinal.Dispose();
                    Clases.Archivos ar = new Clases.Archivos();
                    ar.Nombre = nombreSolo;
                    ar.Ruta = nombre;
                    int nuevoIndice = ar.GuardaArchivo();
                    ((frmRegistros)this.Owner).TextoArchivos = ar.Nombre;
                    ((frmRegistros)this.Owner).idTextoArchivos = nuevoIndice;
                }
                
            }
 

        }

 

    }
}
