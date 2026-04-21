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
        'page-in':    'pageIn 0.6s cubic-bezier(0.22, 1, 0.36, 1) both',
        'modal-in':   'modalIn 0.25s cubic-bezier(0.22, 1, 0.36, 1) both',
        'modal-out':  'modalOut 0.2s ease-in both',
        'backdrop-in':  'backdropIn 0.25s ease both',
        'backdrop-out': 'backdropOut 0.2s ease both',
      },
      keyframes: {
        pageIn: {
          '0%':   { opacity: '0', transform: 'translateY(20px)' },
          '100%': { opacity: '1', transform: 'translateY(0)' },
        },
        modalIn: {
          '0%':   { opacity: '0', transform: 'scale(0.92) translateY(8px)' },
          '100%': { opacity: '1', transform: 'scale(1) translateY(0)' },
        },
        modalOut: {
          '0%':   { opacity: '1', transform: 'scale(1) translateY(0)' },
          '100%': { opacity: '0', transform: 'scale(0.92) translateY(8px)' },
        },
        backdropIn: {
          '0%':   { opacity: '0' },
          '100%': { opacity: '1' },
        },
        backdropOut: {
          '0%':   { opacity: '1' },
          '100%': { opacity: '0' },
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

