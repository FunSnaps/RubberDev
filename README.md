# 🧪 RubberDev — Fullstack Cartoon Collector App

**RubberDev** is a fullstack portfolio project built with a whimsical 1930s rubberhose cartoon aesthetic. It showcases modern software engineering practices through a complete REST API, cloud infrastructure, scalable frontend architecture, and professional tooling.

---

## 🎯 Project Purpose

This app serves two purposes:

1. **Main Project**: A quirky cartoon character collecting app — complete with full CRUD support, file upload (image), and MySQL persistence.
2. **Portfolio Showcase**: Demonstrates Marcus's fullstack skills across frontend, backend, infrastructure, testing, and architectural design.

---

## 🧰 Tech Stack

### 🖼️ Frontend
- **React + Vite**
- **TypeScript**
- **SASS** (custom styling)
- **Zustand** (state management)
- **Formik + Yup** (forms + validation)
- **Atomic Design** + Feature-based folder structure
- **React Router** (SPA routing)
- **ESLint + Prettier + Husky**

### ⚙️ Backend
- **.NET 6** with **Clean Architecture** (inspired by *The Standard* by Hassan Habib)
- **REST API** with Swagger
- **Dapper** for lightweight data access
- **MySQL** as the relational database
- **StorageBroker pattern** for persistence abstraction
- **xUnit** for testing

### ☁️ DevOps & Infrastructure
- **Monorepo**: Single Git repo for frontend + backend
- **Docker** (upcoming setup for local and deployment)
- **GitHub Actions** (planned CI for test + lint)
- **AWS S3** (file storage planned)
- **AWS CloudWatch** (monitoring/logging planned)

---

## 📁 Folder Structure

```
rubberdev/
├── frontend/      # React app
├── backend/       # .NET Clean Architecture API
├── .gitignore
├── README.md
└── Directory.Packages.props (shared NuGet versions)
```

---

## 🧙 Features

- View, add, update, and delete cartoon characters
- Upload images for each character (planned via AWS S3)
- Filter by name, rarity, or origin
- RESTful API with Swagger documentation
- Config-driven and DI-powered architecture
- Strict separation of concerns across layers

---

## 🚀 Setup

```bash
# 1. Clone the repo
git clone https://github.com/FunSnaps/RubberDev.git

# 2. Restore backend dependencies
cd backend
dotnet restore

# 3. Install frontend dependencies
cd ../frontend
npm install

# 4. Run frontend and backend in separate terminals
npm run dev           # frontend
dotnet run --project RubberDev.Api   # backend
```

> ✅ Docker and GitHub Actions support coming soon.

---

## 🤝 Credits

Designed and developed by **Marcus Enrique Elcamel**  
Built for showcasing fullstack engineering skills in real-world architecture.

---

## 📸 Theme Inspiration

> A tribute to the rubberhose animation era — think **Cuphead meets Clean Architecture**.
