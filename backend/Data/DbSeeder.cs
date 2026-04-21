using PromartStore.API.Data;
using PromartStore.API.Models;

namespace PromartStore.API.Data;

/// <summary>
/// Puebla la base de datos en memoria con usuarios y productos de prueba.
/// </summary>
public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        // ── Usuarios ──────────────────────────────────────────────────────────
        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User
                {
                    Id = 1,
                    Username = "user@promart.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Test1234!")
                },
                new User
                {
                    Id = 2,
                    Username = "admin@promart.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin1234!")
                }
            );
        }

        // ── Productos ─────────────────────────────────────────────────────────
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                // ── Electronics (6) ──────────────────────────────────────────
                new()
                {
                    Id = 1,
                    Title = "iPad Air 5ta Generación",
                    Price = 599.99,
                    Description = "Potencia y versatilidad en un diseño ultradelgado. Chip M1, pantalla Liquid Retina de 10,9\" y compatibilidad con Apple Pencil.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/ipad1/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/ipad1/400/400", "https://picsum.photos/seed/ipad1b/400/400", "https://picsum.photos/seed/ipad1c/400/400" },
                    Specifications = "Chip: Apple M1 (CPU 8 núcleos, GPU 7 núcleos). Pantalla: Liquid Retina 10,9 pulgadas, 2360 × 1640 px, 264 ppp, True Tone, antirreflejo. Almacenamiento: 64 GB / 256 GB. Conectividad: Wi-Fi 6 (802.11ax), Bluetooth 5.0, USB-C (USB 3.1 Gen 2). Cámara trasera: 12 MP gran angular, grabación 4K a 60 fps. Cámara frontal: 12 MP ultra gran angular con Center Stage. Batería: hasta 10 horas de navegación web. Compatible con Apple Pencil (2.ª generación) y Smart Keyboard Folio. Touch ID integrado en el botón lateral. Dimensiones: 247,6 × 178,5 × 6,1 mm. Peso: 461 g.",
                    Rating = new ProductRating { Id = 1, ProductId = 1, Rate = 4.6, Count = 534 }
                },
                new()
                {
                    Id = 2,
                    Title = "Apple AirPods Pro (2da Gen)",
                    Price = 249.99,
                    Description = "Cancelación activa de ruido con Transparencia Adaptativa. Audio espacial personalizado y hasta 30 horas de batería con el estuche.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/airpods2/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/airpods2/400/400", "https://picsum.photos/seed/airpods2b/400/400", "https://picsum.photos/seed/airpods2c/400/400" },
                    Specifications = "Chip: Apple H2. Cancelación activa de ruido (ANC) con hasta 2× más potencia. Modo Transparencia Adaptativa ajustable en 4 niveles. Autonomía: hasta 6 horas con ANC; hasta 30 horas totales con estuche. Carga: MagSafe, Lightning y Apple Watch. Resistencia IPX4. Almohadillas S, M y L incluidas. Audio espacial con seguimiento dinámico de cabeza. Compatible con iOS 16 o posterior. Estuche: 45,2 × 60,6 × 21,7 mm. Peso del estuche: 50,8 g.",
                    Rating = new ProductRating { Id = 2, ProductId = 2, Rate = 4.8, Count = 892 }
                },
                new()
                {
                    Id = 3,
                    Title = "Samsung Galaxy S23 Ultra",
                    Price = 1199.99,
                    Description = "Cámara de 200 MP, S Pen integrado y batería de 5000 mAh para un día completo de uso.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/samsung3/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/samsung3/400/400", "https://picsum.photos/seed/samsung3b/400/400", "https://picsum.photos/seed/samsung3c/400/400" },
                    Specifications = "Pantalla: 6,8\" Dynamic AMOLED 2X, QHD+ (3088 × 1440 px), 120 Hz adaptativo. Procesador: Snapdragon 8 Gen 2 for Galaxy. RAM: 12 GB. Almacenamiento: 256 GB / 512 GB / 1 TB. Cámara: 200 MP + gran angular 12 MP + teleobjetivo ×3 + teleobjetivo ×10. Frontal: 12 MP. Batería: 5000 mAh, carga 45 W. S Pen con latencia 2,8 ms. IP68. Android 13 / One UI 5.1. Dimensiones: 163,4 × 78,1 × 8,9 mm. Peso: 234 g.",
                    Rating = new ProductRating { Id = 3, ProductId = 3, Rate = 4.7, Count = 438 }
                },
                new()
                {
                    Id = 4,
                    Title = "Logitech MX Master 3 Mouse Inalámbrico",
                    Price = 79.99,
                    Description = "Mouse avanzado para usuarios exigentes. Rueda MagSpeed, 7 botones programables y funciona en cualquier superficie incluyendo vidrio.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/mouse4/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/mouse4/400/400", "https://picsum.photos/seed/mouse4b/400/400", "https://picsum.photos/seed/mouse4c/400/400" },
                    Specifications = "Sensor: Darkfield de alta precisión, 200–4000 DPI. Rueda MagSpeed electromagnética con modo libre e indexado. 7 botones programables. Conectividad: Bluetooth LE o receptor USB Unifying. Batería recargable USB-C, hasta 70 días. Carga rápida: 3 min = 8 h de uso. Compatible con Windows, macOS, Linux, ChromeOS. Soporte Flow: controla hasta 3 equipos. Dimensiones: 124,9 × 84,3 × 51 mm. Peso: 141 g.",
                    Rating = new ProductRating { Id = 4, ProductId = 4, Rate = 4.6, Count = 671 }
                },
                new()
                {
                    Id = 5,
                    Title = "Sony WH-1000XM5 Auriculares",
                    Price = 348.00,
                    Description = "Cancelación de ruido líder en la industria con hasta 30 horas de batería y audio Hi-Res inalámbrico vía LDAC.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/headphones5/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/headphones5/400/400", "https://picsum.photos/seed/headphones5b/400/400", "https://picsum.photos/seed/headphones5c/400/400" },
                    Specifications = "Cancelación de ruido: 8 micrófonos y 2 procesadores (QN1 + integrado). Transductor: 40 mm con diafragma de carbono. Autonomía: hasta 30 horas con ANC; carga rápida 3 min = 3 h. Multipunto: 2 dispositivos simultáneos. Códecs: SBC, AAC, LDAC. Speak-to-Chat: pausa automática al hablar. Diseño plegable con estuche rígido incluido. Peso: 250 g. Compatible con app Sony Headphones Connect.",
                    Rating = new ProductRating { Id = 5, ProductId = 5, Rate = 4.9, Count = 315 }
                },
                new()
                {
                    Id = 6,
                    Title = "Monitor LG UltraWide 29\" IPS",
                    Price = 279.99,
                    Description = "Panel IPS UltraWide 21:9 con resolución 2560×1080 y 100 Hz para una experiencia inmersiva en trabajo y entretenimiento.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/monitor6/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/monitor6/400/400", "https://picsum.photos/seed/monitor6b/400/400", "https://picsum.photos/seed/monitor6c/400/400" },
                    Specifications = "Tamaño: 29 pulgadas UltraWide (21:9). Panel: IPS. Resolución: 2560 × 1080 (WFHD). Tasa de refresco: 100 Hz. Tiempo de respuesta: 5 ms (GtG). Brillo: 250 cd/m². Contraste: 1000:1. HDR10 compatible. Puertos: 1× HDMI 1.4, 1× DisplayPort 1.2, 2× USB-A 3.0, 1× USB-C (65 W PD). Altavoces integrados: 2 × 7 W. Ajuste de altura, inclinación y rotación. Consumo: 45 W típico. Dimensiones con base: 686 × 404 × 195 mm. Peso: 5,8 kg.",
                    Rating = new ProductRating { Id = 6, ProductId = 6, Rate = 4.4, Count = 287 }
                },

                // ── Jewelery (3) ─────────────────────────────────────────────
                new()
                {
                    Id = 7,
                    Title = "Anillo Oro 18k Colección Naga",
                    Price = 695.00,
                    Description = "Inspirado en el mítico dragón de agua, elaborado artesanalmente en Bali con oro amarillo 18k y detalles en plata 925.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/ring7/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/ring7/400/400", "https://picsum.photos/seed/ring7b/400/400", "https://picsum.photos/seed/ring7c/400/400" },
                    Specifications = "Material: Oro amarillo 18 quilates con detalles en plata de ley 925. Ancho de la banda: 15 mm. Acabado: pulido artesanal con textura de escamas de dragón. Fabricación: artesanal en Bali. Tallas: 5 a 9 (EE.UU.). Peso aprox.: 12,4 g (talla 7). Sin níquel, apto para pieles sensibles. Incluye certificado de autenticidad y caja de regalo. Libre de conflictos (certificado Kimberley Process).",
                    Rating = new ProductRating { Id = 7, ProductId = 7, Rate = 4.6, Count = 400 }
                },
                new()
                {
                    Id = 8,
                    Title = "Anillo Oro 14k con Diamante Solitario",
                    Price = 168.00,
                    Description = "Diamante brillante redondo de 0,5 qt en engaste de garras sobre banda de oro sólido 14k. Certificado GIA incluido.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/diamond8/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/diamond8/400/400", "https://picsum.photos/seed/diamond8b/400/400", "https://picsum.photos/seed/diamond8c/400/400" },
                    Specifications = "Metal: Oro amarillo sólido 14 quilates. Diamante: 0,5 qt, talla brillante redonda, claridad VS2, color G. Engaste: garras de 4 puntas. Pavé lateral: 0,08 ct totales. Certificado GIA incluido. Tallas: 4 a 10 (EE.UU.); ajuste de talla gratuito en 60 días. Ancho de banda: 2 mm. Peso: 2,1 g (talla 6). Libre de conflictos. Caja de regalo incluida.",
                    Rating = new ProductRating { Id = 8, ProductId = 8, Rate = 3.9, Count = 70 }
                },
                new()
                {
                    Id = 9,
                    Title = "Collar Infinito Plata de Ley 925",
                    Price = 44.90,
                    Description = "Colgante símbolo infinito en plata 925 con cadena ajustable de 40 a 45 cm. Acabado pulido espejo.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/necklace9/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/necklace9/400/400", "https://picsum.photos/seed/necklace9b/400/400", "https://picsum.photos/seed/necklace9c/400/400" },
                    Specifications = "Material: Plata de ley 925 con baño anti-oxidación. Colgante: símbolo infinito 20 × 8 mm, acabado pulido espejo. Cadena: tipo cable, 1 mm de grosor, ajustable 40–45 cm. Cierre: mosquetón de langosta. Peso total: 3,2 g. Libre de níquel, plomo y cadmio. Incluye bolsa de terciopelo y tarjeta de cuidado.",
                    Rating = new ProductRating { Id = 9, ProductId = 9, Rate = 4.5, Count = 189 }
                },

                // ── Men's Clothing (10) ───────────────────────────────────────
                new()
                {
                    Id = 10,
                    Title = "Camiseta Slim Fit Premium Manga ¾",
                    Price = 22.30,
                    Description = "Corte slim fit con manga raglan de contraste y cuello henley de 3 botones. Mezcla de algodón peinado y microfibra.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/tshirt10/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/tshirt10/400/400", "https://picsum.photos/seed/tshirt10b/400/400", "https://picsum.photos/seed/tshirt10c/400/400" },
                    Specifications = "Composición: 60% algodón peinado / 40% poliéster microfibra. Peso: 180 g/m². Corte: slim fit con manga raglan de contraste. Cuello: henley con tapeta de 3 botones. Manga: tres cuartos (¾). Costuras reforzadas en hombros y axilas. Lavado a máquina en frío (máx. 30 °C). Tallas: S, M, L, XL, XXL. Disponible en más de 10 colores.",
                    Rating = new ProductRating { Id = 10, ProductId = 10, Rate = 4.1, Count = 259 }
                },
                new()
                {
                    Id = 11,
                    Title = "Chaqueta de Cuero Genuino para Hombre",
                    Price = 55.99,
                    Description = "Chaqueta exterior en cuero genuino de vacuno de primera calidad con forro acolchado ligero y cremallera YKK.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/jacket11/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/jacket11/400/400", "https://picsum.photos/seed/jacket11b/400/400", "https://picsum.photos/seed/jacket11c/400/400" },
                    Specifications = "Exterior: 100% cuero genuino de vacuno. Forro: 100% poliéster acolchado ligero. Cierre: cremallera YKK doble carrera con protector antiviento. Bolsillos: 2 frontales + 1 pecho + 2 interiores. Cuello mao ajustable. Puños con correa y hebilla. Tallas: S a 3XL. Cuidado: limpieza en seco. Peso: 1,4 kg (talla L). Colores: negro, marrón oscuro y cognac.",
                    Rating = new ProductRating { Id = 11, ProductId = 11, Rate = 4.7, Count = 500 }
                },
                new()
                {
                    Id = 12,
                    Title = "Pantalón Chino Slim Fit Hombre",
                    Price = 15.99,
                    Description = "Pantalón chino de tiro medio con 2% elastano para mayor movilidad. Pre-lavado para minimizar encogimiento.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/pants12/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/pants12/400/400", "https://picsum.photos/seed/pants12b/400/400", "https://picsum.photos/seed/pants12c/400/400" },
                    Specifications = "Composición: 98% algodón / 2% elastano. Corte: slim fit, tiro medio. Cierre: cremallera y botón. Bolsillos: 2 delanteros + 2 traseros con tapeta. Largo de entrepierna: 78 cm (talla 32). Tallas: cintura 28–40, largo 28–34. Disponible en 8 colores. Lavado a máquina en frío.",
                    Rating = new ProductRating { Id = 12, ProductId = 12, Rate = 2.1, Count = 430 }
                },
                new()
                {
                    Id = 13,
                    Title = "Chaqueta Biker Cuero Sintético con Capucha",
                    Price = 29.95,
                    Description = "Estilo motero urbano en cuero sintético vegano con capucha desmontable y cremallera asimétrica metálica.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/biker13/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/biker13/400/400", "https://picsum.photos/seed/biker13b/400/400", "https://picsum.photos/seed/biker13c/400/400" },
                    Specifications = "Exterior: 100% poliuretano (cuero sintético vegano). Forro: 75% poliéster / 25% algodón. Capucha desmontable con cordón. Cierre asimétrico metálico estilo motero. Bolsillos: 2 frontales + 1 interior. Puños con correa y hebilla. Lavado a máquina en frío (delicado). Tallas: XS a 3XL. Peso: 0,95 kg. Ideal para 5–18 °C.",
                    Rating = new ProductRating { Id = 13, ProductId = 13, Rate = 2.9, Count = 340 }
                },
                new()
                {
                    Id = 14,
                    Title = "Chubasquero Impermeable 100% Poliéster",
                    Price = 39.99,
                    Description = "Impermeable ligero empaquetable con capucha ajustable y costuras selladas térmicamente. Ideal para actividades al aire libre.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/rain14/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/rain14/400/400", "https://picsum.photos/seed/rain14b/400/400", "https://picsum.photos/seed/rain14c/400/400" },
                    Specifications = "Material: 100% poliéster ripstop con acabado DWR. Costuras selladas térmicamente. Empaquetable en su propio bolsillo (23 × 15 cm plegado). Capucha ajustable en 3 puntos. Bolsillos: 2 frontales con cremallera impermeable. Ventilación bajo los brazos. Peso: 290 g (talla M). Tallas: S a 2XL. Colores: azul marino, negro, rojo y verde bosque.",
                    Rating = new ProductRating { Id = 14, ProductId = 14, Rate = 3.8, Count = 679 }
                },
                new()
                {
                    Id = 15,
                    Title = "Polo Piqué Classic Fit Hombre",
                    Price = 34.99,
                    Description = "Polo de algodón piqué 100% con cuello y mangas en canalé. Corte classic fit, ideal para looks smart-casual.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/polo15/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/polo15/400/400", "https://picsum.photos/seed/polo15b/400/400", "https://picsum.photos/seed/polo15c/400/400" },
                    Specifications = "Composición: 100% algodón piqué peinado. Peso: 220 g/m². Cuello y mangas en canalé 1×1. Cierre: placket de 2 botones. Largo: 74 cm (talla M). Corte: classic fit. Encogimiento previo al corte. Lavado a máquina en frío (máx. 30 °C); no usar lejía. Tallas: S, M, L, XL, XXL. Disponible en 8 colores sólidos.",
                    Rating = new ProductRating { Id = 15, ProductId = 15, Rate = 4.3, Count = 312 }
                },
                new()
                {
                    Id = 16,
                    Title = "Sudadera Hoodie Premium Fleece",
                    Price = 49.99,
                    Description = "Hoodie de forro polar premium con bolsillo canguro y capucha de doble capa con cordón plano. Abrigada y suave al tacto.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/hoodie16/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/hoodie16/400/400", "https://picsum.photos/seed/hoodie16b/400/400", "https://picsum.photos/seed/hoodie16c/400/400" },
                    Specifications = "Composición: 80% algodón / 20% poliéster reciclado. Peso: 320 g/m². Interior: forro polar cepillado. Capucha: doble capa con cordón plano de algodón. Bolsillo canguro frontal. Puños y cintura: canalé acanalado 2×2 para sellado térmico. Tallas: XS, S, M, L, XL, 2XL. Lavado a máquina en frío, secado en tambor a baja temperatura. Disponible en 6 colores.",
                    Rating = new ProductRating { Id = 16, ProductId = 16, Rate = 4.5, Count = 198 }
                },
                new()
                {
                    Id = 17,
                    Title = "Camisa Formal Oxford Manga Larga",
                    Price = 44.90,
                    Description = "Camisa de algodón Oxford 100% con cuello button-down y puños con botón doble. Imprescindible para looks de oficina.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/shirt17/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/shirt17/400/400", "https://picsum.photos/seed/shirt17b/400/400", "https://picsum.photos/seed/shirt17c/400/400" },
                    Specifications = "Composición: 100% algodón Oxford (tejido cesta). Peso: 130 g/m². Cuello: button-down con ballenas removibles. Cierre: botonadura frontal en nácar. Puños: botón doble (puede usarse con gemelos). Bolsillo pecho con detalle bordado. Corte: slim fit. Largo: 78 cm (talla M). Lavado a máquina en frío; planchar a temperatura media. Tallas: S a XXL. Disponible en blanco, azul celeste y azul marino.",
                    Rating = new ProductRating { Id = 17, ProductId = 17, Rate = 4.2, Count = 445 }
                },
                new()
                {
                    Id = 18,
                    Title = "Pantalón Jogger Slim Fit French Terry",
                    Price = 37.50,
                    Description = "Jogger de French terry con cintura elástica y cordón ajustable. Combinación perfecta de comodidad y estilo urbano.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/jogger18/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/jogger18/400/400", "https://picsum.photos/seed/jogger18b/400/400", "https://picsum.photos/seed/jogger18c/400/400" },
                    Specifications = "Composición: 70% algodón / 30% poliéster (French Terry). Peso: 280 g/m². Cintura: elástica con cordón interno plano. Bolsillos: 2 laterales con cremallera, 1 trasero con cremallera. Tobillera: canalé acanalado ajustado. Largo total: 98 cm (talla M). Corte: slim tapered. Lavado a máquina en frío. Tallas: XS a 2XL. Colores: negro, gris melange y azul marino.",
                    Rating = new ProductRating { Id = 18, ProductId = 18, Rate = 4.0, Count = 167 }
                },
                new()
                {
                    Id = 19,
                    Title = "Chaqueta Denim Classic Fit",
                    Price = 59.90,
                    Description = "Clásica chaqueta vaquera de algodón 100% con detalles de costura contrastante y botones metálicos. Atemporal e icónica.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/denim19/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/denim19/400/400", "https://picsum.photos/seed/denim19b/400/400", "https://picsum.photos/seed/denim19c/400/400" },
                    Specifications = "Composición: 100% algodón denim (10 oz/yd²). Lavado: stone-washed para aspecto envejecido natural. Cierre frontal: botones metálicos latón envejecido. Bolsillos: 2 pecho con solapa y botón, 2 laterales laterales. Costuras: triple pespunte en hilo amarillo contrastante. Corte: classic fit, hombros cuadrados. Tallas: S a 3XL. Lavado a máquina en frío (máx. 30 °C), del revés. Colores: azul medio, azul oscuro y negro.",
                    Rating = new ProductRating { Id = 19, ProductId = 19, Rate = 4.4, Count = 523 }
                },

                // ── Women's Clothing (5) ──────────────────────────────────────
                new()
                {
                    Id = 20,
                    Title = "Túnica Deportiva Manga Corta Mujer",
                    Price = 7.95,
                    Description = "100% poliéster catiónico con tecnología moisture-wicking y protección solar UPF 50+. Perfecta para deporte o uso casual.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/tunic20/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/tunic20/400/400", "https://picsum.photos/seed/tunic20b/400/400", "https://picsum.photos/seed/tunic20c/400/400" },
                    Specifications = "Composición: 100% poliéster catiónico interlock moisture-wicking. Peso: 150 g/m². Cuello redondo holgado. Manga corta sin costuras laterales. Largo: 70 cm (talla M). Protección solar UPF 50+ certificado. Lavado a máquina en frío, secado en tambor a baja temperatura. Tallas: XS a 3XL. Disponible en más de 15 colores. Corte relaxed fit.",
                    Rating = new ProductRating { Id = 20, ProductId = 20, Rate = 4.5, Count = 146 }
                },
                new()
                {
                    Id = 21,
                    Title = "Blusa Cuello Barco con Detalle en V",
                    Price = 9.85,
                    Description = "95% rayón y 5% spandex con caída fluida. Cuello barco con inset en V para un look elegante y versátil.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/blouse21/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/blouse21/400/400", "https://picsum.photos/seed/blouse21b/400/400", "https://picsum.photos/seed/blouse21c/400/400" },
                    Specifications = "Composición: 95% rayón / 5% spandex. Peso: 180 g/m². Cuello barco con detalle de inset en V. Manga corta con dobladillo en canalé fino. Largo: 63 cm (talla M). Corte regular fit con caída fluida. Lavado preferible en seco; lavado a máquina ciclo delicado en frío. Tallas: S a 3XL. Disponible en 12 colores sólidos.",
                    Rating = new ProductRating { Id = 21, ProductId = 21, Rate = 4.7, Count = 130 }
                },
                new()
                {
                    Id = 22,
                    Title = "Vestido Cóctel Elegante Línea A",
                    Price = 67.99,
                    Description = "Vestido hasta la rodilla con silueta fit-and-flare y encaje floral en el corpino. Ideal para bodas, galas y cócteles.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/dress22/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/dress22/400/400", "https://picsum.photos/seed/dress22b/400/400", "https://picsum.photos/seed/dress22c/400/400" },
                    Specifications = "Exterior: 90% poliéster / 10% elastano. Forro: 100% poliéster. Largo: aprox. 100 cm (talla M). Silueta: A-line fit-and-flare. Detalle: encaje floral en corpino. Cierre: cremallera oculta en espalda. Lavado a mano en frío o limpieza en seco. Tallas: XS a XL. Colores: negro, champán, borgoña y azul marino.",
                    Rating = new ProductRating { Id = 22, ProductId = 22, Rate = 3.6, Count = 235 }
                },
                new()
                {
                    Id = 23,
                    Title = "Pantalón Tiro Alto Pierna Slim Mujer",
                    Price = 34.90,
                    Description = "Pantalón de tiro alto que resalta la figura con pierna estrecha y cónica. Pretina ancha de 8 cm y cierre invisible lateral.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/trousers23/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/trousers23/400/400", "https://picsum.photos/seed/trousers23b/400/400", "https://picsum.photos/seed/trousers23c/400/400" },
                    Specifications = "Composición: 72% poliéster / 24% rayón / 4% elastano. Tiro: alto (28 cm). Cierre: cremallera lateral invisible. Largo: 95 cm (talla 28). Pretina: 8 cm. Bolsillos frontales invisibles. Lavado en seco recomendado. Tallas: cintura 24–36. Disponible en 6 colores: negro, gris grafito, azul marino, kaki, blanco hueso y terracota.",
                    Rating = new ProductRating { Id = 23, ProductId = 23, Rate = 4.1, Count = 301 }
                },
                new()
                {
                    Id = 24,
                    Title = "Parka Acolchada Larga Mujer",
                    Price = 89.99,
                    Description = "Exterior resistente al agua con relleno de plumón 80/20 y forro polar. Disponible en 6 colores, capucha desmontable.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/puffer24/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/puffer24/400/400", "https://picsum.photos/seed/puffer24b/400/400", "https://picsum.photos/seed/puffer24c/400/400" },
                    Specifications = "Exterior: 100% poliéster con recubrimiento PU resistente al agua (5000 mm columna de agua). Relleno: 80% plumón / 20% plumas (700 cuin). Forro: polar suave 100% poliéster. Longitud: 90 cm (talla M). Cierre: cremallera doble carrera con solapa de botones. Bolsillos: 2 laterales + 1 interior. Capucha desmontable acolchada. Lavado a máquina en frío, ciclo suave; secar con pelotas de tenis. Tallas: XS a XXL. Colores: negro, azul marino, verde botella, camel, rosa palo y gris perla.",
                    Rating = new ProductRating { Id = 24, ProductId = 24, Rate = 4.3, Count = 417 }
                },
            };

            context.Products.AddRange(products);
        }

        context.SaveChanges();
    }
}
