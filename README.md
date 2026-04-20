# Promart Store 🛒

Prototipo de e-commerce desarrollado como reto técnico. Permite iniciar sesión, visualizar productos por categoría y gestionar un carrito de compras.

## Stack Tecnológico

| Capa       | Tecnologías                                          |
|------------|------------------------------------------------------|
| Frontend   | React 19 · TypeScript · Vite · Tailwind CSS · Zustand · React Router v6 · Axios |
| Backend    | .NET 8 · ASP.NET Core Web API · EF Core InMemory · JWT Auth |

---

## Estructura del proyecto

```
promart-store/
├── frontend/          # React + TypeScript (Vite)
├── backend/           # .NET 8 Web API
├── .gitignore
└── README.md
```

---

## Requisitos previos

- **Node.js** ≥ 18 → [nodejs.org](https://nodejs.org)
- **.NET 8 SDK** → [dot.net/download](https://dotnet.microsoft.com/download/dotnet/8)

---

## Instalación y ejecución local

### 1. Clonar el repositorio

```bash
git clone https://github.com/<tu-usuario>/promart-store.git
cd promart-store
```

### 2. Backend (.NET 8)

```bash
cd backend
dotnet restore
dotnet run
# API disponible en: http://localhost:5000
```

### 3. Frontend (React)

```bash
cd frontend
npm install
npm run dev
# App disponible en: http://localhost:5173
```

> El frontend apunta al backend en `http://localhost:5000` por defecto.  
> Si cambias el puerto del backend, ajusta `VITE_API_URL` en `frontend/.env`.

---

## Credenciales de prueba

| Usuario               | Contraseña  |
|-----------------------|-------------|
| user@promart.com      | Test1234!   |
| admin@promart.com     | Admin1234!  |

---

## Endpoints de la API

| Método | Ruta                                 | Auth | Descripción               |
|--------|--------------------------------------|------|---------------------------|
| POST   | `/api/auth/login`                    | ❌   | Iniciar sesión → JWT      |
| GET    | `/api/products`                      | ✅   | Listar todos los productos |
| GET    | `/api/products/category/{category}`  | ✅   | Filtrar por categoría      |
| GET    | `/api/products/{id}`                 | ✅   | Obtener producto por ID    |

### Categorías disponibles

`electronics` · `jewelery` · `men's clothing` · `women's clothing`

---

## Funcionalidades

- **Login** con validación de campos y mensajes de error descriptivos
- Token JWT almacenado en `localStorage` · rutas protegidas con redirect automático
- **Home** con grilla de productos responsive y skeleton loading
- Filtro de productos por categoría (botones rápidos)
- Selector de cantidad por producto antes de agregar al carrito
- **Carrito** persistente en `localStorage` via Zustand Persist
- Actualización en tiempo real de totales al agregar/eliminar/modificar cantidad
- Responsive design: mobile-first con Tailwind CSS

---

## Diseño (Mockup)

Inspirado en un diseño limpio y moderno de tienda online con:
- Paleta de colores: blanco + indigo (#4f46e5)
- Tarjetas de producto con imagen, rating, precio y selector de cantidad
- Navbar sticky con contador de carrito
- Resumen de pedido sticky en la vista de carrito

---

## Despliegue

> *Instrucciones de despliegue pendientes (Firebase / Render / Railway)*

---

## Autor

Desarrollado como parte del reto técnico **Promart Store**.
