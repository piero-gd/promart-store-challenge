# Promart Store 🛒

Prototipo de e-commerce desarrollado como reto técnico. Permite iniciar sesión, visualizar productos por categoría y gestionar un carrito de compras.

## 🔗 Demo en producción

| | URL |
|---|---|
| **Frontend** | [promart-store-pg.netlify.app](https://promart-store-pg.netlify.app) |
| **Backend API** | [promart-store-challenge-production.up.railway.app](https://promart-store-challenge-production.up.railway.app) |

---

## Stack Tecnológico

| Capa       | Tecnologías                                          |
|------------|------------------------------------------------------|
| Frontend   | React 19 · TypeScript · Vite · Tailwind CSS · Zustand · React Router v6 · Axios · Sonner |
| Backend    | .NET 8 · ASP.NET Core Web API · EF Core InMemory · JWT Auth · BCrypt |
| Deploy     | Netlify (frontend) · Railway (backend) |

---

## Estructura del proyecto

```
promart-store/
├── frontend/          # React + TypeScript (Vite)
│   └── src/
│       ├── features/  # Arquitectura feature-based
│       │   ├── auth/
│       │   ├── cart/
│       │   └── products/
│       ├── components/ # Componentes globales (Navbar, Layout)
│       ├── api/        # Axios client con interceptor JWT
│       └── types/      # Tipos compartidos y utilidades
├── backend/           # .NET 8 Web API
│   ├── Controllers/
│   ├── Data/          # DbContext + Seeder
│   ├── Models/
│   ├── DTOs/
│   └── Services/      # TokenService (JWT)
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
git clone https://github.com/piero-gd/promart-store.git
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
> Si necesitas cambiar la URL, crea un archivo `frontend/.env.local`:
> ```
> VITE_API_URL=http://localhost:5000
> ```

---

## Variables de entorno

### Frontend (`frontend/.env.local`)

| Variable | Descripción | Valor por defecto |
|---|---|---|
| `VITE_API_URL` | URL base del backend | `http://localhost:5000` |

### Backend (variables de entorno o `appsettings.json`)

| Variable | Descripción |
|---|---|
| `JwtSettings__SecretKey` | Clave secreta para firmar JWT (mín. 32 chars) |
| `ALLOWED_ORIGINS` | Orígenes permitidos en CORS, separados por coma |

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
- Filtro de productos por categoría con URL persistente (`?category=...`)
- **Detalle de producto** con carrusel de imágenes (crossfade), tabs descripción/especificaciones y sugeridos
- Selector de cantidad antes de agregar al carrito
- **MiniCart** accesible desde el Navbar (drawer en mobile, dropdown en desktop)
- **Carrito** persistente en `localStorage` via Zustand Persist
- Actualización en tiempo real de totales · confirmación antes de vaciar
- Notificaciones **Toast** en acciones clave (agregar, eliminar, vaciar carrito, errores)
- Animaciones de transición entre páginas
- Responsive design: mobile-first con Tailwind CSS

---

## Decisiones técnicas

### Arquitectura feature-based
Cada dominio (`auth`, `products`, `cart`) contiene sus propios `pages/`, `components/`, `hooks/` y `store/`. Facilita la escalabilidad y el mantenimiento sin acoplamiento entre features.

### Hooks como capa de lógica
Los componentes de página son UI pura. Toda la lógica (fetch, estado, handlers) vive en hooks dedicados (`useProducts`, `useProductDetail`, `useCart`), siguiendo el principio de responsabilidad única.

### Zustand sobre Context API + useReducer
Se eligió Zustand por su API mínima sin boilerplate, persistencia con `zustand/middleware` en una línea, y suscripciones granulares que evitan re-renders innecesarios — ventajas que con Context API requieren soluciones adicionales como `useMemo`, `useRef` o múltiples contextos.

### Layout Route con Outlet
El `Layout` usa el patrón de React Router v6 con `<Outlet />`, garantizando que el Navbar nunca se desmonte ni parpadee al navegar entre páginas.

### Base de datos InMemory
El backend usa EF Core InMemory con datos semilla (`DbSeeder`). Apropiado para una prueba técnica al no requerir infraestructura de base de datos externa.

---

## Autor

Piero Gallo.
