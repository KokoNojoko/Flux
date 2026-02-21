# Flux Payment Gateway - Development Roadmap

This roadmap provides a structured guide for building your payment gateway simulator. Each section represents a milestone with specific issues to complete.

---

## 🏗️ Phase 1: Foundation (Infrastructure Setup)

### Issue 1: Configure Entity Framework DbContext and Entity Mappings
**Labels:** `infrastructure`, `priority:high`

**Description:**
Configure FluxDbContext with proper entity configurations using Fluent API.

**Tasks:**
- [ ] Create entity configuration classes for each entity (Merchant, Customer, Payment, Transaction, WebhookEvent)
- [ ] Configure primary keys, indexes, and relationships
- [ ] Configure value object (Address) as owned entity
- [ ] Set up proper cascade delete rules
- [ ] Add database connection string configuration in appsettings.json

**Acceptance Criteria:**
- All entities properly mapped with relationships
- Migrations can be generated successfully
- Database schema matches domain model

---

### Issue 2: Wire Up Dependency Injection
**Labels:** `infrastructure`, `priority:high`

**Description:**
Configure dependency injection container with all required services.

**Tasks:**
- [ ] Register DbContext with connection string
- [ ] Register UnitOfWork and repositories
- [ ] Register MediatR handlers
- [ ] Register FluentValidation validators
- [ ] Create extension methods for clean DI registration (e.g., `AddInfrastructure()`, `AddApplication()`)

**Acceptance Criteria:**
- Application starts without DI errors
- All services resolve correctly
- Scoped lifetime for DbContext and UnitOfWork

---

### Issue 3: Create Database Migrations
**Labels:** `infrastructure`, `priority:high`

**Description:**
Generate initial EF Core migration and set up database.

**Tasks:**
- [ ] Run `dotnet ef migrations add InitialCreate`
- [ ] Review generated migration for correctness
- [ ] Apply migration to create database
- [ ] Add seed data for testing (optional)

**Acceptance Criteria:**
- Database created successfully
- All tables match entity definitions
- Foreign keys and indexes created

---

## 👤 Phase 2: Merchant Management

### Issue 4: Implement CreateMerchant Command Handler
**Labels:** `application`, `priority:high`

**Description:**
Complete the CreateMerchantCommandHandler to create new merchants.

**Tasks:**
- [ ] Implement handler logic in CreateMerchantCommandHandler
- [ ] Generate unique API key for merchant
- [ ] Validate merchant data (unique email, valid webhook URL)
- [ ] Save merchant via UnitOfWork
- [ ] Return created merchant ID

**Acceptance Criteria:**
- Merchants can be created with valid data
- Duplicate emails are rejected
- API key is generated automatically

---

### Issue 5: Implement GetAllMerchants Query Handler
**Labels:** `application`, `priority:high`

**Description:**
Complete the GetAllMerchantsQueryHandler to retrieve merchants.

**Tasks:**
- [ ] Implement handler logic
- [ ] Add pagination support
- [ ] Add filtering options (by name, email, status)
- [ ] Map to response DTOs

**Acceptance Criteria:**
- Can retrieve all merchants
- Pagination works correctly
- Filtering returns expected results

---

### Issue 6: Add GetMerchantById Query
**Labels:** `application`, `priority:medium`

**Description:**
Create query to retrieve a single merchant by ID.

**Tasks:**
- [ ] Create GetMerchantByIdQuery and handler
- [ ] Include related data (customers count, payments count)
- [ ] Handle not found scenario

---

### Issue 7: Add UpdateMerchant Command
**Labels:** `application`, `priority:medium`

**Description:**
Create command to update merchant details.

**Tasks:**
- [ ] Create UpdateMerchantCommand and handler
- [ ] Add validation
- [ ] Allow updating name, email, webhook URL
- [ ] Regenerate API key on request

---

### Issue 8: Create Merchant API Endpoints
**Labels:** `api`, `priority:high`

**Description:**
Create REST API endpoints for merchant management.

**Tasks:**
- [ ] Create MerchantsController
- [ ] POST /api/merchants - Create merchant
- [ ] GET /api/merchants - List merchants (with pagination)
- [ ] GET /api/merchants/{id} - Get merchant by ID
- [ ] PUT /api/merchants/{id} - Update merchant
- [ ] DELETE /api/merchants/{id} - Deactivate merchant
- [ ] POST /api/merchants/{id}/regenerate-key - Regenerate API key

**Acceptance Criteria:**
- All endpoints return proper HTTP status codes
- Validation errors return 400 with details
- Not found returns 404

---

## 👥 Phase 3: Customer Management

### Issue 9: Implement CreateCustomer Command
**Labels:** `application`, `priority:high`

**Description:**
Create command to add customers linked to merchants.

**Tasks:**
- [ ] Create CreateCustomerCommand and handler
- [ ] Validate merchant exists
- [ ] Validate unique email per merchant
- [ ] Handle Address value object

---

### Issue 10: Implement Customer Queries
**Labels:** `application`, `priority:medium`

**Description:**
Create queries for retrieving customers.

**Tasks:**
- [ ] GetCustomersByMerchantId query
- [ ] GetCustomerById query
- [ ] Add pagination and filtering

---

### Issue 11: Create Customer API Endpoints
**Labels:** `api`, `priority:high`

**Description:**
Create REST API endpoints for customer management.

**Tasks:**
- [ ] POST /api/merchants/{merchantId}/customers
- [ ] GET /api/merchants/{merchantId}/customers
- [ ] GET /api/customers/{id}
- [ ] PUT /api/customers/{id}

---

## 💳 Phase 4: Payment Processing (Core Feature)

### Issue 12: Implement AuthorizePayment Command
**Labels:** `application`, `priority:high`

**Description:**
Create the payment authorization flow.

**Tasks:**
- [ ] Create AuthorizePaymentCommand with amount, currency, customerId, idempotencyKey
- [ ] Validate idempotency (return existing payment if key exists)
- [ ] Create Payment entity with Pending status
- [ ] Create Transaction with Authorise type
- [ ] Simulate authorization success/failure (random or rule-based)
- [ ] Update Payment status to Authorised or Failed
- [ ] Trigger webhook event

**Acceptance Criteria:**
- Payments can be authorized
- Idempotency prevents duplicate charges
- Transaction record created
- Webhook event queued

---

### Issue 13: Implement CapturePayment Command
**Labels:** `application`, `priority:high`

**Description:**
Capture an authorized payment.

**Tasks:**
- [ ] Create CapturePaymentCommand with paymentId, amount (optional partial capture)
- [ ] Validate payment exists and is Authorised
- [ ] Create Capture transaction
- [ ] Update Payment status to Captured
- [ ] Trigger webhook event

---

### Issue 14: Implement RefundPayment Command
**Labels:** `application`, `priority:high`

**Description:**
Refund a captured payment.

**Tasks:**
- [ ] Create RefundPaymentCommand with paymentId, amount, reason
- [ ] Validate payment is Captured
- [ ] Support partial refunds
- [ ] Create Refund transaction
- [ ] Update Payment status to Refunded (if fully refunded)
- [ ] Trigger webhook event

---

### Issue 15: Implement VoidPayment Command
**Labels:** `application`, `priority:medium`

**Description:**
Void an authorized (not yet captured) payment.

**Tasks:**
- [ ] Create VoidPaymentCommand
- [ ] Validate payment is Authorised
- [ ] Create Void transaction
- [ ] Update Payment status to Voided
- [ ] Trigger webhook event

---

### Issue 16: Implement Payment Queries
**Labels:** `application`, `priority:medium`

**Description:**
Create queries for retrieving payment information.

**Tasks:**
- [ ] GetPaymentById - include transactions
- [ ] GetPaymentsByMerchant - with filters (status, date range, customer)
- [ ] GetPaymentsByCustomer

---

### Issue 17: Create Payment API Endpoints
**Labels:** `api`, `priority:high`

**Description:**
Create REST API endpoints for payment processing.

**Tasks:**
- [ ] POST /api/payments/authorize - Authorize payment
- [ ] POST /api/payments/{id}/capture - Capture payment
- [ ] POST /api/payments/{id}/refund - Refund payment
- [ ] POST /api/payments/{id}/void - Void payment
- [ ] GET /api/payments/{id} - Get payment details
- [ ] GET /api/payments - List payments with filters

**Acceptance Criteria:**
- Proper API key authentication
- Idempotency key support
- Clear error messages for invalid operations

---

### Issue 18: Add API Key Authentication Middleware
**Labels:** `api`, `infrastructure`, `priority:high`

**Description:**
Secure payment endpoints with API key authentication.

**Tasks:**
- [ ] Create API key authentication middleware
- [ ] Validate X-API-Key header against merchant API keys
- [ ] Set current merchant in request context
- [ ] Return 401 for invalid/missing keys

---

## 🔔 Phase 5: Webhook System

### Issue 19: Implement Webhook Event Creation
**Labels:** `application`, `priority:medium`

**Description:**
Create webhook events when payment status changes.

**Tasks:**
- [ ] Create IWebhookService interface
- [ ] Generate webhook payload with payment/event details
- [ ] Create WebhookEvent entity with Pending status
- [ ] Store in database for delivery

---

### Issue 20: Implement Webhook Delivery Service
**Labels:** `infrastructure`, `priority:medium`

**Description:**
Background service to deliver webhook events.

**Tasks:**
- [ ] Create hosted background service
- [ ] Query pending webhook events
- [ ] HTTP POST to merchant webhook URL
- [ ] Implement retry logic with exponential backoff (1→2→15→60→360 min)
- [ ] Update event status (Delivered, Failed, Retrying)
- [ ] Mark as Failed after max attempts

---

### Issue 21: Add Webhook Management Endpoints
**Labels:** `api`, `priority:low`

**Description:**
Endpoints to view webhook event history.

**Tasks:**
- [ ] GET /api/webhooks - List webhook events for merchant
- [ ] GET /api/webhooks/{id} - Get webhook event details
- [ ] POST /api/webhooks/{id}/retry - Manually retry failed webhook

---

## 🧪 Phase 6: Testing & Polish

### Issue 22: Add Unit Tests for Domain Layer
**Labels:** `testing`, `priority:medium`

**Description:**
Test domain entities and business logic.

**Tasks:**
- [ ] Test entity creation and validation
- [ ] Test Payment state transitions
- [ ] Test WebhookEvent retry logic
- [ ] Test value objects (Address)

---

### Issue 23: Add Unit Tests for Application Layer
**Labels:** `testing`, `priority:medium`

**Description:**
Test command and query handlers.

**Tasks:**
- [ ] Mock repositories and UnitOfWork
- [ ] Test CreateMerchant command
- [ ] Test payment flow commands
- [ ] Test validation rules

---

### Issue 24: Add Integration Tests
**Labels:** `testing`, `priority:low`

**Description:**
End-to-end API tests.

**Tasks:**
- [ ] Set up test database (in-memory or test container)
- [ ] Test full payment flow via API
- [ ] Test authentication
- [ ] Test error scenarios

---

### Issue 25: Update README Documentation
**Labels:** `priority:low`

**Description:**
Document the project for users.

**Tasks:**
- [ ] Architecture overview
- [ ] API documentation
- [ ] Setup instructions
- [ ] Example requests

---

### Issue 26: Add Swagger/OpenAPI Documentation
**Labels:** `api`, `priority:low`

**Description:**
Add interactive API documentation.

**Tasks:**
- [ ] Configure Swashbuckle
- [ ] Add XML comments to controllers
- [ ] Configure API key authentication in Swagger UI

---

## 📋 Quick Reference: Issue Count by Phase

| Phase | Issues | Priority High |
|-------|--------|---------------|
| Phase 1: Foundation | 3 | 3 |
| Phase 2: Merchant Management | 5 | 3 |
| Phase 3: Customer Management | 3 | 2 |
| Phase 4: Payment Processing | 7 | 5 |
| Phase 5: Webhooks | 3 | 0 |
| Phase 6: Testing & Polish | 5 | 0 |
| **Total** | **26** | **13** |

---

## 🚀 Getting Started

Start with **Phase 1** issues in order:
1. Entity configurations
2. Dependency injection
3. Database migrations

Then move to **Phase 2** to get your first working feature (Merchant CRUD).

Once Merchants work end-to-end, tackle **Phase 4** (Payments) as that's the core value of the gateway.

Good luck! 🎉
