## 🔄 Flow Overview

1. Client sends HTTP request
2. Azure Function validates & processes request
3. Data stored in MongoDB
4. Message published to Service Bus
5. Worker Function processes message
6. Failures go to Dead Letter Queue (DLQ)
7. DLQ Function handles retries/logging/audit

## 🏗️ Architecture Diagram

Below is the end-to-end Azure event-driven architecture for the Product API:

![Azure Architecture](Docs/architecture.png)
