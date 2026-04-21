/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: {
          50:  '#fff5e6',
          100: '#ffddb3',
          500: '#ff9900',
          600: '#ff8000',
          700: '#cc6600',
        },
      },
      animation: {
        'page-in': 'pageIn 0.6s cubic-bezier(0.22, 1, 0.36, 1) both',
      },
      keyframes: {
        pageIn: {
          '0%':   { opacity: '0', transform: 'translateY(20px)' },
          '100%': { opacity: '1', transform: 'translateY(0)' },
        },
      },
    },
  },
  plugins: [
    function ({ addUtilities }) {
      addUtilities({
        '.scrollbar-hide': {
          '-ms-overflow-style': 'none',
          'scrollbar-width': 'none',
        },
        '.scrollbar-hide::-webkit-scrollbar': {
          'display': 'none',
        },
      });
    },
  ],
}

