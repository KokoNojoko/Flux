#!/bin/bash
# Flux Payment Gateway - GitHub Issues Creator
# 
# SETUP:
# 1. Install GitHub CLI: brew install gh
# 2. Authenticate: gh auth login
# 3. Run this script: chmod +x scripts/create-issues.sh && ./scripts/create-issues.sh
#
# This will create all 26 issues with proper labels and milestones.

set -e

REPO="KokoNojoko/Finty"

echo "🏷️  Creating labels..."
gh label create "infrastructure" --description "Database, DI, configuration" --color "0052CC" --repo $REPO 2>/dev/null || echo "  Label 'infrastructure' exists"
gh label create "domain" --description "Domain entities, business rules" --color "5319E7" --repo $REPO 2>/dev/null || echo "  Label 'domain' exists"
gh label create "api" --description "REST API endpoints" --color "1D76DB" --repo $REPO 2>/dev/null || echo "  Label 'api' exists"
gh label create "application" --description "Commands, queries, handlers" --color "0E8A16" --repo $REPO 2>/dev/null || echo "  Label 'application' exists"
gh label create "testing" --description "Unit and integration tests" --color "FBCA04" --repo $REPO 2>/dev/null || echo "  Label 'testing' exists"
gh label create "priority:high" --description "Must have" --color "B60205" --repo $REPO 2>/dev/null || echo "  Label 'priority:high' exists"
gh label create "priority:medium" --description "Should have" --color "FF9F1C" --repo $REPO 2>/dev/null || echo "  Label 'priority:medium' exists"
gh label create "priority:low" --description "Nice to have" --color "C5DEF5" --repo $REPO 2>/dev/null || echo "  Label 'priority:low' exists"

echo ""
echo "🎯 Creating milestones..."
gh api repos/$REPO/milestones -X POST -f title="Phase 1: Foundation" -f description="Infrastructure setup, DI wiring, database configuration" 2>/dev/null || echo "  Milestone 'Phase 1' exists"
gh api repos/$REPO/milestones -X POST -f title="Phase 2: Merchant Management" -f description="Complete merchant CRUD operations" 2>/dev/null || echo "  Milestone 'Phase 2' exists"
gh api repos/$REPO/milestones -X POST -f title="Phase 3: Customer Management" -f description="Customer CRUD operations" 2>/dev/null || echo "  Milestone 'Phase 3' exists"
gh api repos/$REPO/milestones -X POST -f title="Phase 4: Payment Processing" -f description="Core payment flow" 2>/dev/null || echo "  Milestone 'Phase 4' exists"
gh api repos/$REPO/milestones -X POST -f title="Phase 5: Webhooks" -f description="Webhook event system" 2>/dev/null || echo "  Milestone 'Phase 5' exists"
gh api repos/$REPO/milestones -X POST -f title="Phase 6: Testing & Polish" -f description="Tests and documentation" 2>/dev/null || echo "  Milestone 'Phase 6' exists"

echo ""
echo "📝 Creating issues..."

# Phase 1: Foundation
echo "  Phase 1: Foundation"
gh issue create --repo $REPO --title "Configure Entity Framework DbContext and entity mappings" \
  --body "## Description
Configure FluxDbContext with proper entity configurations using Fluent API.

## Tasks
- [ ] Create entity configuration classes for each entity
- [ ] Configure primary keys, indexes, and relationships
- [ ] Configure Address as owned entity
- [ ] Set up cascade delete rules
- [ ] Add connection string configuration" \
  --label "infrastructure" --label "priority:high" --milestone "Phase 1: Foundation"

gh issue create --repo $REPO --title "Wire up Dependency Injection" \
  --body "## Description
Configure DI container with all required services.

## Tasks
- [ ] Register DbContext with connection string
- [ ] Register UnitOfWork and repositories
- [ ] Register MediatR handlers
- [ ] Register FluentValidation validators
- [ ] Create extension methods for clean registration" \
  --label "infrastructure" --label "priority:high" --milestone "Phase 1: Foundation"

gh issue create --repo $REPO --title "Create database migrations" \
  --body "## Tasks
- [ ] Run dotnet ef migrations add InitialCreate
- [ ] Review generated migration
- [ ] Apply migration to create database" \
  --label "infrastructure" --label "priority:high" --milestone "Phase 1: Foundation"

# Phase 2: Merchant Management
echo "  Phase 2: Merchant Management"
gh issue create --repo $REPO --title "Implement CreateMerchant command handler" \
  --body "## Tasks
- [ ] Implement handler logic
- [ ] Generate unique API key
- [ ] Validate unique email
- [ ] Save via UnitOfWork" \
  --label "application" --label "priority:high" --milestone "Phase 2: Merchant Management"

gh issue create --repo $REPO --title "Implement GetAllMerchants query handler" \
  --body "## Tasks
- [ ] Implement handler logic
- [ ] Add pagination support
- [ ] Add filtering options
- [ ] Map to response DTOs" \
  --label "application" --label "priority:high" --milestone "Phase 2: Merchant Management"

gh issue create --repo $REPO --title "Add GetMerchantById query" \
  --body "## Tasks
- [ ] Create query and handler
- [ ] Include related data counts
- [ ] Handle not found" \
  --label "application" --label "priority:medium" --milestone "Phase 2: Merchant Management"

gh issue create --repo $REPO --title "Add UpdateMerchant command" \
  --body "## Tasks
- [ ] Create command and handler
- [ ] Add validation
- [ ] Support API key regeneration" \
  --label "application" --label "priority:medium" --milestone "Phase 2: Merchant Management"

gh issue create --repo $REPO --title "Create Merchant API endpoints" \
  --body "## Endpoints
- [ ] POST /api/merchants
- [ ] GET /api/merchants
- [ ] GET /api/merchants/{id}
- [ ] PUT /api/merchants/{id}
- [ ] DELETE /api/merchants/{id}
- [ ] POST /api/merchants/{id}/regenerate-key" \
  --label "api" --label "priority:high" --milestone "Phase 2: Merchant Management"

# Phase 3: Customer Management
echo "  Phase 3: Customer Management"
gh issue create --repo $REPO --title "Implement CreateCustomer command" \
  --body "## Tasks
- [ ] Create command and handler
- [ ] Validate merchant exists
- [ ] Validate unique email per merchant
- [ ] Handle Address value object" \
  --label "application" --label "priority:high" --milestone "Phase 3: Customer Management"

gh issue create --repo $REPO --title "Implement Customer queries" \
  --body "## Tasks
- [ ] GetCustomersByMerchantId query
- [ ] GetCustomerById query
- [ ] Add pagination and filtering" \
  --label "application" --label "priority:medium" --milestone "Phase 3: Customer Management"

gh issue create --repo $REPO --title "Create Customer API endpoints" \
  --body "## Endpoints
- [ ] POST /api/merchants/{merchantId}/customers
- [ ] GET /api/merchants/{merchantId}/customers
- [ ] GET /api/customers/{id}
- [ ] PUT /api/customers/{id}" \
  --label "api" --label "priority:high" --milestone "Phase 3: Customer Management"

# Phase 4: Payment Processing
echo "  Phase 4: Payment Processing"
gh issue create --repo $REPO --title "Implement AuthorizePayment command" \
  --body "## Tasks
- [ ] Create command with amount, currency, customerId, idempotencyKey
- [ ] Validate idempotency
- [ ] Create Payment with Pending status
- [ ] Create Authorise transaction
- [ ] Simulate success/failure
- [ ] Trigger webhook event" \
  --label "application" --label "priority:high" --milestone "Phase 4: Payment Processing"

gh issue create --repo $REPO --title "Implement CapturePayment command" \
  --body "## Tasks
- [ ] Create command with paymentId, amount
- [ ] Validate payment is Authorised
- [ ] Create Capture transaction
- [ ] Update status to Captured
- [ ] Trigger webhook" \
  --label "application" --label "priority:high" --milestone "Phase 4: Payment Processing"

gh issue create --repo $REPO --title "Implement RefundPayment command" \
  --body "## Tasks
- [ ] Create command with paymentId, amount, reason
- [ ] Validate payment is Captured
- [ ] Support partial refunds
- [ ] Create Refund transaction
- [ ] Trigger webhook" \
  --label "application" --label "priority:high" --milestone "Phase 4: Payment Processing"

gh issue create --repo $REPO --title "Implement VoidPayment command" \
  --body "## Tasks
- [ ] Create command
- [ ] Validate payment is Authorised
- [ ] Create Void transaction
- [ ] Update status to Voided
- [ ] Trigger webhook" \
  --label "application" --label "priority:medium" --milestone "Phase 4: Payment Processing"

gh issue create --repo $REPO --title "Implement Payment queries" \
  --body "## Tasks
- [ ] GetPaymentById with transactions
- [ ] GetPaymentsByMerchant with filters
- [ ] GetPaymentsByCustomer" \
  --label "application" --label "priority:medium" --milestone "Phase 4: Payment Processing"

gh issue create --repo $REPO --title "Create Payment API endpoints" \
  --body "## Endpoints
- [ ] POST /api/payments/authorize
- [ ] POST /api/payments/{id}/capture
- [ ] POST /api/payments/{id}/refund
- [ ] POST /api/payments/{id}/void
- [ ] GET /api/payments/{id}
- [ ] GET /api/payments" \
  --label "api" --label "priority:high" --milestone "Phase 4: Payment Processing"

gh issue create --repo $REPO --title "Add API key authentication middleware" \
  --body "## Tasks
- [ ] Create authentication middleware
- [ ] Validate X-API-Key header
- [ ] Set merchant in request context
- [ ] Return 401 for invalid keys" \
  --label "api" --label "infrastructure" --label "priority:high" --milestone "Phase 4: Payment Processing"

# Phase 5: Webhooks
echo "  Phase 5: Webhooks"
gh issue create --repo $REPO --title "Implement webhook event creation" \
  --body "## Tasks
- [ ] Create IWebhookService interface
- [ ] Generate webhook payload
- [ ] Create WebhookEvent with Pending status" \
  --label "application" --label "priority:medium" --milestone "Phase 5: Webhooks"

gh issue create --repo $REPO --title "Implement webhook delivery service" \
  --body "## Tasks
- [ ] Create hosted background service
- [ ] Query pending events
- [ ] HTTP POST to webhook URL
- [ ] Implement retry with exponential backoff
- [ ] Update event status" \
  --label "infrastructure" --label "priority:medium" --milestone "Phase 5: Webhooks"

gh issue create --repo $REPO --title "Add webhook management endpoints" \
  --body "## Endpoints
- [ ] GET /api/webhooks
- [ ] GET /api/webhooks/{id}
- [ ] POST /api/webhooks/{id}/retry" \
  --label "api" --label "priority:low" --milestone "Phase 5: Webhooks"

# Phase 6: Testing & Polish
echo "  Phase 6: Testing & Polish"
gh issue create --repo $REPO --title "Add unit tests for Domain layer" \
  --body "## Tasks
- [ ] Test entity creation
- [ ] Test Payment state transitions
- [ ] Test WebhookEvent retry logic
- [ ] Test value objects" \
  --label "testing" --label "priority:medium" --milestone "Phase 6: Testing & Polish"

gh issue create --repo $REPO --title "Add unit tests for Application layer" \
  --body "## Tasks
- [ ] Mock repositories
- [ ] Test command handlers
- [ ] Test validation rules" \
  --label "testing" --label "priority:medium" --milestone "Phase 6: Testing & Polish"

gh issue create --repo $REPO --title "Add integration tests" \
  --body "## Tasks
- [ ] Set up test database
- [ ] Test full payment flow
- [ ] Test authentication
- [ ] Test error scenarios" \
  --label "testing" --label "priority:low" --milestone "Phase 6: Testing & Polish"

gh issue create --repo $REPO --title "Update README documentation" \
  --body "## Tasks
- [ ] Architecture overview
- [ ] API documentation
- [ ] Setup instructions
- [ ] Example requests" \
  --label "priority:low" --milestone "Phase 6: Testing & Polish"

gh issue create --repo $REPO --title "Add Swagger/OpenAPI documentation" \
  --body "## Tasks
- [ ] Configure Swashbuckle
- [ ] Add XML comments
- [ ] Configure API key auth in Swagger UI" \
  --label "api" --label "priority:low" --milestone "Phase 6: Testing & Polish"

echo ""
echo "✅ Done! Created 26 issues across 6 milestones."
echo "   View at: https://github.com/$REPO/issues"
