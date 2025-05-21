# 🧪 RubberDev — Fullstack Card-Collector Gacha Game + Portfolio

**RubberDev** is a portfolio-worthy, fullstack card-collector gacha game built with a whimsical 1930s rubberhose cartoon aesthetic. It combines a modern React-based SPA with a Hassan Habib–style Clean Architecture back end and robust DevOps, demonstrating end-to-end software craftsmanship.


## 🎯 Project Overview

1. **Gacha Game**: Collect and manage cartoon character cards via a RESTful gacha pull system.
2. **Portfolio Showcase**: Static and dynamic pages highlighting your skills, blog posts, architecture diagrams, and a live demo of the game.


## 🧰 Tech Stack

### 🖼️ Frontend Core

* React + Vite
* TypeScript
* SASS (custom styling)
* Zustand (state management)
* Formik + Yup (forms & validation)
* **Atomic Design** folder structure (atoms, molecules, organisms, templates, pages, features)
* React Router (client-side routing)
* ESLint + Prettier + Husky (linting & formatting)

### ⭐ Frontend Additions

* Storybook (component-driven dev)
* Jest + React Testing Library (unit tests)
* Cypress or Playwright (E2E tests)
* Next.js or Remix (SSR/SSG + image optimization)
* Tailwind CSS or Radix UI (utility-first & accessible components)
* PWA support (offline caching, installable app)
* Web Vitals + Sentry RUM (performance monitoring)
* axe-core + Lighthouse CI (accessibility audits)
* Google Analytics or Plausible (user analytics)

### ⚙️ Backend Core

* .NET 6 Clean Architecture “The Standard” (Hassan Habib style)
* REST API (controllers, DTOs, middleware)
* Dapper (lightweight data access)
* MySQL (relational DB)
* StorageBroker pattern (persistence abstraction)
* xUnit (unit testing)
* Swagger UI (interactive API docs)

### 🚀 Backend Additions

* MediatR (CQRS: command/query separation)
* HotChocolate (GraphQL endpoint)
* Redis (caching via ElastiCache)
* ASP.NET Core Identity / IdentityServer (JWT authentication)
* OpenTelemetry (distributed tracing)
* Serilog → AWS CloudWatch (structured logging)
* API Versioning & ADRs (Architecture Decision Records)
* Rate-limiting & security headers middleware

### ☁️ DevOps & Infrastructure Core

* Monorepo (frontend + backend)
* Docker + docker-compose (local orchestration)
* GitHub Actions (CI: lint & tests)
* AWS S3 (card art & asset storage)
* AWS CloudWatch (logs & metrics)

### 🔧 DevOps & Infrastructure Additions

* Terraform or AWS CDK (IaC) + tflint / OPA policies
* AWS CloudFront CDN (static asset delivery)
* Full CI/CD pipeline (lint → test → build → push → deploy to ECR → ECS/EKS)
* CloudWatch Alarms → Slack / PagerDuty alerts
* Dependabot / Snyk / GitHub Advanced Security (vulnerability scanning)
* k6 or JMeter (load & performance testing)

### 🌐 Cross-Cutting & Future Directions

* AWS SNS / SQS or Kafka (event-driven async flows)
* Backend-for-Frontend (BFF) aggregation layer
* i18n: react-intl or i18next (localisation)
* Feature flags: LaunchDarkly or self-hosted
* React Native or Flutter mobile companion

## 🧙 Features

* **User Management**: Signup, login, JWT authentication, protected routes.
* **Gacha Pulls**: Spend in-game currency to randomly draw cards based on rarity tables.
* **Inventory & Collection**: View owned cards in a searchable, filterable grid.
* **Deck Builder**: Drag-and-drop interface to assemble custom decks from your collection.
* **Card CRUD**: Admin interface to create, update, delete card definitions, including image uploads.
* **Pull History & Leaderboards**: Track past pulls and global rankings with caching for performance.
* **Portfolio Page**: Static and dynamic content—bio, architecture diagrams, tech demos, blog links, live game.
* **Offline & Mobile**: PWA support for offline access; future mobile companion app.
* **Analytics & Monitoring**: Web Vitals, Sentry RUM, Google Analytics, OpenTelemetry traces.
* **Quality & Security**: Unit, integration, E2E tests; accessibility audits; rate-limiting; policy-as-code.


## 📁 Architecture & Folder Structure

```plaintext
rubberdev/
├── .github/                  # GitHub workflows
│   └── workflows/
│       ├── ci.yml
│       └── cd.yml
├── terraform/                # IaC modules & policies
│   ├── modules/
│   │   ├── s3/
│   │   ├── rds/
│   │   ├── elasticache/
│   │   └── cloudfront/
│   ├── env/
│   │   └── prod.tfvars
│   └── main.tf
├── docker-compose.yml        # local orchestration
├── .gitignore
├── frontend/                 # React + Vite app
│   ├── public/
│   ├── src/
│   │   ├── assets/
│   │   ├── components/
│   │   │   ├── atoms/
│   │   │   ├── molecules/
│   │   │   ├── organisms/
│   │   │   └── templates/
│   │   ├── features/
│   │   │   ├── auth/
│   │   │   ├── gacha/
│   │   │   ├── collection/
│   │   │   └── portfolio/
│   │   ├── stores/
│   │   ├── pages/
│   │   ├── App.tsx
│   │   ├── router.tsx
│   │   └── index.tsx
│   ├── .storybook/
│   ├── tests/
│   │   ├── unit/
│   │   └── e2e/
│   ├── vite.config.ts
│   ├── tsconfig.json
│   └── package.json
├── src/                      # Backend solution
│   ├── RubberDev.Api/        # Presentation layer
│   │   ├── Controllers/
│   │   ├── DTOs/
│   │   ├── Middleware/
│   │   └── Program.cs
│   ├── RubberDev.Application/ # Use-cases & interfaces
│   │   ├── Services/
│   │   └── Interfaces/
│   ├── RubberDev.Domain/     # Entities & value objects
│   │   ├── Entities/
│   │   ├── ValueObjects/
│   │   └── Enums/
│   ├── RubberDev.Infrastructure/ # Data access & external services
│   │   ├── Data/
│   │   ├── Caching/
│   │   └── Identity/
│   └── RubberDev.Tests/      # xUnit tests
│       ├── Api.Tests/
│       ├── Application.Tests/
│       └── Domain.Tests/
└── README.md                 # This file
```


## 🚀 Implementation Roadmap

**Phase 1 – Foundations**

   * MySQL + Redis in `docker-compose`
   * Terraform modules for S3, RDS, ElastiCache, CloudFront, IAM, CloudWatch + tflint/OPA

**Phase 2 – Auth & Documentation**

   * ASP.NET Core Identity / IdentityServer for JWT
   * Swagger UI (v1) + ADRs folder
   * Frontend: login/register (Formik + Yup), protected routes

**Phase 3 – Card & Portfolio CRUD**

   * Dapper mappings & seed scripts for Cards, Inventory, PullHistory, Currency
   * CRUD REST endpoints + GraphQL schema (HotChocolate)
   * Portfolio page: static “About me”, architecture diagrams, analytics

**Phase 4 – Gacha Engine & Caching**

   * GachaService (MediatR + rarity tables + RNG)
   * Redis caching for pull rates & leaderboards
   * Frontend: pull screen, animations, result modal, PWA caching

**Phase 5 – Collection & Deck Builder**

   * Collection grid with filters & deck-builder drag/drop
   * Versioned REST endpoints & GraphQL Playground
   * Rate-limiting & security headers

**Phase 6 – Testing & Quality Gates**

   * Storybook stories, Jest/RTL unit tests, Cypress/Playwright E2E
   * axe-core & Lighthouse CI in CI

**Phase 7 – Observability & Alerts**

   * OpenTelemetry (frontend & backend)
   * Sentry RUM + Web Vitals
   * CloudWatch Alarms → Slack/PagerDuty

**Phase 8 – Performance & Scaling**

   * Next.js/Remix migration (SSR/SSG + image opt)
   * CloudFront CDN & WAF
   * k6/JMeter load tests; tune scaling

**Phase 9 – Polish & Launch**

   * i18n with react-intl or i18next
   * Feature flags (LaunchDarkly)
   * Mobile companion (React Native/Flutter)
   * Finalize docs: ADRs, diagrams, CI badges


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


## 🤝 Credits

Designed and developed by **Marcus Enrique Elcamel**  
Built for showcasing fullstack engineering skills in real-world architecture, inspired by the golden age of cartoons and modern software craftsmanship.


## 📸 Theme Inspiration

> A tribute to the rubberhose animation era — think **Cuphead meets Clean Architecture**.
