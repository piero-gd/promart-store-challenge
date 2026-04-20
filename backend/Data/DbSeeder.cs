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
                // Electronics
                new()
                {
                    Id = 1,
                    Title = "Fjallraven - Foldsack No. 1 Backpack",
                    Price = 109.95,
                    Description = "Your perfect pack for everyday use and walks in the forest.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/backpack1/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/backpack1/400/400", "https://picsum.photos/seed/backpack1b/400/400", "https://picsum.photos/seed/backpack1c/400/400" },
                    Specifications = "Material: 100% G-1000 HeavyDuty Eco (65% polyéster reciclado / 35% algodón orgánico). Dimensiones: 44 × 30 × 15 cm. Capacidad: 20 litros. Panel trasero acolchado con sistema de ventilación. Tirantes ajustables con espuma de alta densidad. Manga interior para laptop de hasta 15 pulgadas. Cierre principal reforzado con resistencia al agua. Bolsillo frontal con organización interna para accesorios. Compatible con sistema de hidratación (tubo incluido). Disponible en 7 colores. Peso del producto: 0,9 kg.",
                    Rating = new ProductRating { Id = 1, ProductId = 1, Rate = 3.9, Count = 120 }
                },
                new()
                {
                    Id = 2,
                    Title = "Apple AirPods Pro (2nd Gen)",
                    Price = 249.99,
                    Description = "Active noise cancellation for immersive sound. Adaptive Transparency.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/airpods2/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/airpods2/400/400", "https://picsum.photos/seed/airpods2b/400/400", "https://picsum.photos/seed/airpods2c/400/400" },
                    Specifications = "Chip: Apple H2. Cancelación activa de ruido (ANC) con hasta 2× más potencia respecto a la generación anterior. Modo Transparencia Adaptativa ajustable en 4 niveles. Autonomía: hasta 6 horas de escucha con ANC activado; hasta 30 horas totales con el estuche de carga. Carga del estuche: MagSafe, Lightning y Apple Watch. Resistencia al agua y sudor IPX4 (auriculares y estuche). Talla S, M y L de almohadillas de silicona. Audio espacial personalizado con seguimiento dinámico de cabeza. Compatible con iOS 16 o posterior, iPadOS 16 o posterior. Dimensiones del estuche: 45,2 × 60,6 × 21,7 mm. Peso del estuche: 50,8 g.",
                    Rating = new ProductRating { Id = 2, ProductId = 2, Rate = 4.8, Count = 892 }
                },
                new()
                {
                    Id = 3,
                    Title = "Samsung Galaxy S23 Ultra",
                    Price = 1199.99,
                    Description = "200MP camera · S Pen · 5000mAh battery for all-day power.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/samsung3/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/samsung3/400/400", "https://picsum.photos/seed/samsung3b/400/400", "https://picsum.photos/seed/samsung3c/400/400" },
                    Specifications = "Pantalla: 6,8 pulgadas Dynamic AMOLED 2X, resolución QHD+ (3088 × 1440 px), 120 Hz adaptativo (1–120 Hz). Procesador: Snapdragon 8 Gen 2 for Galaxy. RAM: 12 GB LPDDR5X. Almacenamiento: 256 GB / 512 GB / 1 TB (UFS 3.1). Cámara trasera: principal 200 MP (f/1.7) + gran angular 12 MP + teleobjetivo 10 MP (×3) + teleobjetivo 10 MP (×10). Cámara frontal: 12 MP. Batería: 5000 mAh, carga rápida 45 W, carga inalámbrica 15 W, carga inversa 4,5 W. S Pen integrado con latencia de 2,8 ms. Resistencia al agua y polvo IP68. Sistema operativo: Android 13 con One UI 5.1. Dimensiones: 163,4 × 78,1 × 8,9 mm. Peso: 234 g.",
                    Rating = new ProductRating { Id = 3, ProductId = 3, Rate = 4.7, Count = 438 }
                },
                new()
                {
                    Id = 4,
                    Title = "Logitech MX Master 3 Wireless Mouse",
                    Price = 79.99,
                    Description = "Advanced wireless mouse for power users. Works on any surface.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/mouse4/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/mouse4/400/400", "https://picsum.photos/seed/mouse4b/400/400", "https://picsum.photos/seed/mouse4c/400/400" },
                    Specifications = "Sensor: Darkfield de alta precisión, rango 200–4000 DPI ajustable. Rueda de desplazamiento MagSpeed electromagnética con modo libre e indexado. 7 botones programables (incluye botones adelante/atrás). Conectividad: Bluetooth Low Energy o receptor USB Unifying. Batería recargable USB-C, hasta 70 días con carga completa; 3 minutos de carga ofrecen 8 horas de uso. Compatible con Windows, macOS, Linux y ChromeOS. Funciona en cualquier superficie, incluyendo vidrio. Diseño ergonómico para mano derecha. Soporte para Flow: controla hasta 3 equipos simultáneamente. Dimensiones: 124,9 × 84,3 × 51 mm. Peso: 141 g.",
                    Rating = new ProductRating { Id = 4, ProductId = 4, Rate = 4.6, Count = 671 }
                },
                new()
                {
                    Id = 5,
                    Title = "Sony WH-1000XM5 Headphones",
                    Price = 348.00,
                    Description = "Industry-leading noise canceling with up to 30-hour battery life.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/headphones5/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/headphones5/400/400", "https://picsum.photos/seed/headphones5b/400/400", "https://picsum.photos/seed/headphones5c/400/400" },
                    Specifications = "Cancelación de ruido: 8 micrófonos y 2 procesadores (QN1 + integrado) para la mejor cancelación de la industria. Transductor: unidad de 40 mm con diafragma de carbono. Autonomía: hasta 30 horas con ANC activado; carga rápida de 3 minutos = 3 horas de escucha. Conexión multipunto: vinculación simultánea con 2 dispositivos. Códecs de audio: SBC, AAC, LDAC (audio Hi-Res inalámbrico). Función Speak-to-Chat: pausa automática al hablar. Micrófono integrado para llamadas cristalinas. Diseño plegable con estuche rígido incluido. Peso: 250 g. Dimensiones: 254 × 195 × 75 mm (plegado). Compatible con la app Sony Headphones Connect.",
                    Rating = new ProductRating { Id = 5, ProductId = 5, Rate = 4.9, Count = 315 }
                },
                // Jewelery
                new()
                {
                    Id = 6,
                    Title = "John Hardy Women's Legends Naga Gold Ring",
                    Price = 695.00,
                    Description = "From our Legends Collection, the Naga was inspired by the mythical water dragon.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/ring6/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/ring6/400/400", "https://picsum.photos/seed/ring6b/400/400", "https://picsum.photos/seed/ring6c/400/400" },
                    Specifications = "Material: Oro amarillo 18 quilates con detalles en plata de ley 925. Ancho de la banda: 15 mm. Acabado: pulido artesanal con textura de escamas de dragón. Fabricación: artesanal en Bali con técnicas tradicionales transmitidas por generaciones. Tallas disponibles: 5 a 9 (EE.UU.). Peso aproximado: 12,4 g (talla 7). Sin níquel, apto para pieles sensibles. Incluye certificado de autenticidad y caja de regalo de la marca. Limpieza recomendada con paño suave y solución jabonosa neutra. Libre de conflictos (certificado Kimberley Process).",
                    Rating = new ProductRating { Id = 6, ProductId = 6, Rate = 4.6, Count = 400 }
                },
                new()
                {
                    Id = 7,
                    Title = "Solid Gold Petite Micropave Diamond Ring",
                    Price = 168.00,
                    Description = "Satisfaction Guaranteed. Return or exchange any order within 30 days.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/diamond7/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/diamond7/400/400", "https://picsum.photos/seed/diamond7b/400/400", "https://picsum.photos/seed/diamond7c/400/400" },
                    Specifications = "Metal: Oro amarillo sólido de 14 quilates. Diamante central: 0,5 quilates, talla brillante redonda. Claridad: VS2. Color: G (casi incoloro). Engaste: garras de 4 puntas. Pavé de diamantes laterales de 0,08 ct totales en la banda. Certificado GIA incluido. Tallas disponibles: 4 a 10 (EE.UU.); ajuste de talla gratuito dentro de los 60 días. Ancho de la banda: 2 mm. Altura del engaste: 5 mm. Peso total: 2,1 g (talla 6). Libre de conflictos. Caja de regalo incluida.",
                    Rating = new ProductRating { Id = 7, ProductId = 7, Rate = 3.9, Count = 70 }
                },
                new()
                {
                    Id = 8,
                    Title = "White Gold Plated Princess Cut CZ Earrings",
                    Price = 9.99,
                    Description = "Classic Created Wedding Engagement Solitaire Diamond Promise Ring.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/earrings8/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/earrings8/400/400", "https://picsum.photos/seed/earrings8b/400/400", "https://picsum.photos/seed/earrings8c/400/400" },
                    Specifications = "Base: Plata de ley 925 con baño de oro blanco de 18 quilates. Piedra central: Zirconia cúbica talla princesa de 5 × 5 mm (equivalente visual a 1 ct). Cierre: presión estándar (push-back) con tope de seguridad. Peso por par: 2,3 g. Libre de níquel e hipoalergénico. Grosor del poste: 0,8 mm, compatible con perforaciones estándar. Acabado: alto brillo espejado. Dimensiones del arete: 7 × 7 mm. Incluye estuche de terciopelo. Limpieza: paño suave; evitar contacto con agua, perfumes y productos químicos.",
                    Rating = new ProductRating { Id = 8, ProductId = 8, Rate = 3.0, Count = 400 }
                },
                new()
                {
                    Id = 9,
                    Title = "Rose Gold Plated Bracelet Set",
                    Price = 29.99,
                    Description = "Set of 5 beautiful rose gold tone bracelets with cubic zirconia stones.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/bracelet9/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/bracelet9/400/400", "https://picsum.photos/seed/bracelet9b/400/400", "https://picsum.photos/seed/bracelet9c/400/400" },
                    Specifications = "Contenido: Set de 5 pulseras. Material: Latón con baño de oro rosa de 14 quilates. Piedras: Zirconias cúbicas en corte redondo de 2 mm. Diámetro interior: 60 mm (diseño abierto ajustable). Rango de muñeca compatible: 14–20 cm. Peso total del set: 45 g. Libre de plomo y níquel. Resistencia: no sumergir; evitar contacto prolongado con agua o sudor. Incluye caja de regalo de cartón kraft. Cada pulsera tiene un diseño diferente: trenzada, lisa, con textura diamante, con zirconias continuas y con nudo.",
                    Rating = new ProductRating { Id = 9, ProductId = 9, Rate = 4.2, Count = 233 }
                },
                new()
                {
                    Id = 10,
                    Title = "Sterling Silver Infinity Necklace",
                    Price = 44.90,
                    Description = "925 sterling silver infinity symbol pendant necklace with adjustable chain.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/necklace10/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/necklace10/400/400", "https://picsum.photos/seed/necklace10b/400/400", "https://picsum.photos/seed/necklace10c/400/400" },
                    Specifications = "Material: Plata de ley 925 con baño anti-oxidación. Colgante: símbolo infinito de 20 × 8 mm, acabado pulido espejo. Cadena: tipo cable (1 mm de grosor), longitud ajustable entre 40 y 45 cm. Cierre: mosquetón de langosta. Grosor del colgante: 1,5 mm. Peso total: 3,2 g. Libre de níquel, plomo y cadmio. Incluye bolsa de terciopelo y tarjeta de cuidado del producto. Limpieza: paño suave o ultrasonido con agua y jabón neutro. Uso recomendado: ocasiones especiales o uso diario con cuidado básico.",
                    Rating = new ProductRating { Id = 10, ProductId = 10, Rate = 4.5, Count = 189 }
                },
                // Men's Clothing
                new()
                {
                    Id = 11,
                    Title = "Mens Casual Premium Slim Fit T-Shirts",
                    Price = 22.30,
                    Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/tshirt11/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/tshirt11/400/400", "https://picsum.photos/seed/tshirt11b/400/400", "https://picsum.photos/seed/tshirt11c/400/400" },
                    Specifications = "Composición: 60% algodón peinado / 40% poliéster microfibra. Peso del tejido: 180 g/m². Corte: slim fit con manga raglan de contraste. Cuello: tipo henley con tapeta de 3 botones. Largo de la manga: tres cuartos (¾). Costuras: reforzadas en hombros y axilas. Instrucciones de lavado: lavado a máquina en frío (máx. 30 °C), centrifugado suave, no usar lejía, planchar a baja temperatura. Tallas disponibles: S, M, L, XL, XXL (guía de tallas incluida). Disponible en más de 10 colores. Encogimiento previo al corte para mantener la forma.",
                    Rating = new ProductRating { Id = 11, ProductId = 11, Rate = 4.1, Count = 259 }
                },
                new()
                {
                    Id = 12,
                    Title = "Mens Cotton Jacket",
                    Price = 55.99,
                    Description = "Great outerwear jackets for men. Outer shell made from genuine cowhide leather.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/jacket12/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/jacket12/400/400", "https://picsum.photos/seed/jacket12b/400/400", "https://picsum.photos/seed/jacket12c/400/400" },
                    Specifications = "Exterior: 100% cuero genuino de vacuno (cowhide) de primera calidad. Forro: 100% poliéster acolchado ligero. Cierre principal: cremallera YKK de doble carrera con protector antiviento. Bolsillos: 2 frontales con cremallera, 1 pecho con botón a presión, 2 interiores de seguridad. Cuello: mao ajustable con corchete interno. Puños: con correa y hebilla metálica regulable. Tallas disponibles: S, M, L, XL, 2XL, 3XL. Instrucciones de cuidado: limpieza en seco o paño húmedo; no lavar a máquina. Peso aproximado: 1,4 kg (talla L). Color disponible: negro, marrón oscuro y café cognac.",
                    Rating = new ProductRating { Id = 12, ProductId = 12, Rate = 4.7, Count = 500 }
                },
                new()
                {
                    Id = 13,
                    Title = "Mens Casual Slim Fit Chino Pants",
                    Price = 15.99,
                    Description = "The color could be slightly different between on the screen and in practice.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/pants13/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/pants13/400/400", "https://picsum.photos/seed/pants13b/400/400", "https://picsum.photos/seed/pants13c/400/400" },
                    Specifications = "Composición: 98% algodón / 2% elastano para mayor movilidad. Corte: slim fit de tiro medio. Cintura: con presillas para cinturón (ancho 3,5 cm) y cierre de cremallera y botón. Bolsillos: 2 delanteros tipo slash, 2 traseros con tapeta y botón. Pierna: estrecha, largo de entrepierna 78 cm (talla 32). Pre-lavado para minimizar encogimiento. Instrucciones: lavado a máquina en frío, secado tendido. Tallas disponibles: cintura 28–40, largo 28–34 (combinaciones completas). Disponible en 8 colores (caqui, azul marino, gris, negro, arena, verde oliva, burdeos y marrón). Confección reforzada en zonas de tensión.",
                    Rating = new ProductRating { Id = 13, ProductId = 13, Rate = 2.1, Count = 430 }
                },
                new()
                {
                    Id = 14,
                    Title = "Lock and Love Men's Removable Hooded Faux Leather Biker Jacket",
                    Price = 29.95,
                    Description = "100% POLYURETHANE(shell) 100% POLYESTER(lining) 75% POLYESTER 25% COTTON.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/biker14/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/biker14/400/400", "https://picsum.photos/seed/biker14b/400/400", "https://picsum.photos/seed/biker14c/400/400" },
                    Specifications = "Exterior: 100% poliuretano (cuero sintético vegano). Forro del cuerpo: 75% poliéster / 25% algodón. Capucha: desmontable con cordón ajustable, fijación mediante cremallera oculta. Cierre frontal: cremallera asimétrica metálica estilo motero. Hardware: herrajes en tono plata envejecida. Bolsillos: 2 frontales con cremallera, 1 bolsillo interior con cremallera. Puños: con correa de ajuste y hebilla. Instrucciones de cuidado: lavado a máquina en frío (delicado), secar en plano; no centrifugar ni planchar el exterior. Tallas: XS, S, M, L, XL, 2XL, 3XL. Peso aproximado: 0,95 kg. Ideal para uso urbano en temperaturas de 5–18 °C.",
                    Rating = new ProductRating { Id = 14, ProductId = 14, Rate = 2.9, Count = 340 }
                },
                new()
                {
                    Id = 15,
                    Title = "Rain Jacket 100% Polyester",
                    Price = 39.99,
                    Description = "Ideal for all outdoor activities and beach sporting events.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/rain15/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/rain15/400/400", "https://picsum.photos/seed/rain15b/400/400", "https://picsum.photos/seed/rain15c/400/400" },
                    Specifications = "Material exterior: 100% poliéster ripstop con acabado DWR (Durable Water Repellent). Costuras: selladas térmicamente para impermeabilidad total. Empaquetable: se pliega en su propio bolsillo interior (dimensiones plegado: 23 × 15 cm). Capucha: ajustable en 3 puntos (parte trasera, laterales y visera). Dobladillo: elástico ajustable con cordón. Bolsillos: 2 frontales con cremallera impermeable. Ventilación: ojales de malla bajo los brazos. Peso: 290 g (talla M). Temperatura de uso recomendada: 5–20 °C. Tallas disponibles: S, M, L, XL, 2XL. Colores: azul marino, negro, rojo y verde bosque.",
                    Rating = new ProductRating { Id = 15, ProductId = 15, Rate = 3.8, Count = 679 }
                },
                // Women's Clothing
                new()
                {
                    Id = 16,
                    Title = "Opna Women's Short Sleeve Moisture Tunic",
                    Price = 7.95,
                    Description = "100% Polyester, Machine wash, 100% cationic polyester interlock.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/tunic16/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/tunic16/400/400", "https://picsum.photos/seed/tunic16b/400/400", "https://picsum.photos/seed/tunic16c/400/400" },
                    Specifications = "Composición: 100% poliéster catiónico interlock con tecnología de gestión de humedad (moisture-wicking). Peso del tejido: 150 g/m². Cuello: escote redondo holgado. Manga: corta, sin costuras laterales en las mangas para mayor comodidad. Largo de la prenda: 70 cm (talla M). Protección solar: UPF 50+ certificado. Instrucciones de lavado: lavado a máquina en frío, secado en tambor a baja temperatura. Tallas disponibles: XS, S, M, L, XL, 2XL, 3XL. Disponible en más de 15 colores. Corte: relaxed fit, adecuado para actividades deportivas y uso casual. Fabricación conforme a estándares de comercio justo.",
                    Rating = new ProductRating { Id = 16, ProductId = 16, Rate = 4.5, Count = 146 }
                },
                new()
                {
                    Id = 17,
                    Title = "MBJ Women's Solid Short Sleeve Boat Neck V",
                    Price = 9.85,
                    Description = "95% RAYON 5% SPANDEX, Made in USA or Imported, Do Not Bleach.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/boatneck17/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/boatneck17/400/400", "https://picsum.photos/seed/boatneck17b/400/400", "https://picsum.photos/seed/boatneck17c/400/400" },
                    Specifications = "Composición: 95% rayón / 5% spandex. Peso del tejido: 180 g/m². Cuello: barco (boat neck) con detalle de inset en V. Manga: corta con dobladillo en canalé fino. Largo de la prenda: 63 cm (talla M). Corte: regular fit con caída fluida. Instrucciones de lavado: preferiblemente limpieza en seco; lavado a máquina permitido en ciclo delicado con agua fría; no usar lejía ni suavizante. Tallas disponibles: S, M, L, XL, 2XL, 3XL. Fabricación: hecho en EE.UU. o importado (varía según color). Disponible en 12 colores sólidos. Apto para uso laboral, casual y salidas nocturnas.",
                    Rating = new ProductRating { Id = 17, ProductId = 17, Rate = 4.7, Count = 130 }
                },
                new()
                {
                    Id = 18,
                    Title = "Womens Cocktail Dress - Elegant A-Line",
                    Price = 67.99,
                    Description = "Classic knee-length cocktail dress with lace detailing and fit-and-flare silhouette.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/dress18/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/dress18/400/400", "https://picsum.photos/seed/dress18b/400/400", "https://picsum.photos/seed/dress18c/400/400" },
                    Specifications = "Composición exterior: 90% poliéster / 10% elastano. Forro interior: 100% poliéster. Largo: hasta la rodilla (aproximadamente 100 cm en talla M). Silueta: A-line fit-and-flare con pecho ajustado. Detalle: encaje floral en el corpino superior (parte delantera y trasera). Cierre: cremallera oculta en la espalda. Instrucciones de cuidado: lavado a mano en frío o limpieza en seco; no centrifugar. Tallas disponibles: XS, S, M, L, XL. Sin varillas ni relleno interno. Ocasiones: bodas, galas, cócteles, cumpleaños y eventos formales. Colores disponibles: negro, champán, borgoña y azul marino.",
                    Rating = new ProductRating { Id = 18, ProductId = 18, Rate = 3.6, Count = 235 }
                },
                new()
                {
                    Id = 19,
                    Title = "Women's Slim Leg Trousers High-Waisted",
                    Price = 34.90,
                    Description = "High-waist design that emphasizes curves with a slim-fit tapered leg.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/trousers19/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/trousers19/400/400", "https://picsum.photos/seed/trousers19b/400/400", "https://picsum.photos/seed/trousers19c/400/400" },
                    Specifications = "Composición: 72% poliéster / 24% rayón / 4% elastano. Tiro: alto (28 cm desde la entrepierna). Cierre: cremallera lateral invisible con presilla de seguridad. Pierna: estrecha y cónica, largo total de 95 cm (talla 28). Bolsillos: 2 bolsillos frontales invisibles. Pretina: ancha (8 cm) con efecto liso que favorece la silueta. Instrucciones de lavado: limpieza en seco recomendada; lavado a máquina ciclo delicado permitido. Tallas disponibles: cintura 24–36 (guía de tallas incluida). Disponible en 6 colores: negro, gris grafito, azul marino, kaki, blanco hueso y terracota. Adecuado para uso laboral y ocasiones semi-formales.",
                    Rating = new ProductRating { Id = 19, ProductId = 19, Rate = 4.1, Count = 301 }
                },
                new()
                {
                    Id = 20,
                    Title = "Women's Longline Puffer Jacket",
                    Price = 89.99,
                    Description = "Water-resistant quilted outer shell with cosy fleece lining. Available in 6 colours.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/puffer20/400/400",
                    Images = new List<string> { "https://picsum.photos/seed/puffer20/400/400", "https://picsum.photos/seed/puffer20b/400/400", "https://picsum.photos/seed/puffer20c/400/400" },
                    Specifications = "Exterior: 100% poliéster con recubrimiento de poliuretano resistente al agua (clasificación 5000 mm columna de agua). Relleno: 80% plumón / 20% plumas (poder de llenado 700 cuin). Forro: forro polar suave (100% poliéster) para máximo confort térmico. Longitud: hasta el muslo (90 cm en talla M). Cierre: cremallera frontal con doble carrera y solapa de botones a presión. Bolsillos: 2 laterales con cremallera, 1 interior con botón a presión. Puños: elásticos internos para sellado térmico. Capucha: desmontable y acolchada. Instrucciones: lavado a máquina en frío, ciclo suave; secado en tambor con pelotas de tenis para restaurar el volumen. Tallas: XS, S, M, L, XL, XXL. Colores: negro, azul marino, verde botella, camel, rosa palo y gris perla.",
                    Rating = new ProductRating { Id = 20, ProductId = 20, Rate = 4.3, Count = 417 }
                },
            };

            context.Products.AddRange(products);
        }

        context.SaveChanges();
    }
}
