# GitHub Actions Workflows

This repository contains several GitHub Actions workflows for building, testing, and deploying the .NET Web API application.

## Available Workflows

### 1. Build and Test (`build.yml`)
- **Triggers**: Push to `main`/`develop` branches, Pull Requests
- **Purpose**: Basic build and test pipeline
- **Features**:
  - Restores NuGet dependencies
  - Builds the solution in Release configuration
  - Runs tests
  - Publishes the application
  - Uploads build artifacts

### 2. CI/CD Pipeline (`ci-cd.yml`)
- **Triggers**: Push to `main`/`develop` branches, Pull Requests, Manual dispatch
- **Purpose**: Comprehensive CI/CD with code quality and security checks
- **Features**:
  - Build and test (same as basic workflow)
  - NuGet package caching for faster builds
  - Code coverage collection
  - SonarCloud integration for code quality
  - Security vulnerability scanning with Trivy
  - SARIF output for GitHub Security tab

### 3. Deploy (`deploy.yml`)
- **Triggers**: Push to `main` branch, version tags, Manual dispatch
- **Purpose**: Automated deployment to different environments
- **Features**:
  - Environment-based deployment (staging/production)
  - Manual deployment with environment selection
  - Deployment status notifications

## Setup Requirements

### Required Secrets
- `SONAR_TOKEN`: SonarCloud authentication token (for code quality job)

### Environment Protection
- `staging`: For staging deployments
- `production`: For production deployments

## Usage

### Automatic Triggers
- **Push to `develop`**: Triggers build, test, and code quality checks
- **Push to `main`**: Triggers full pipeline including deployment to production
- **Pull Requests**: Triggers build and test for code review

### Manual Deployment
1. Go to Actions tab in GitHub
2. Select "Deploy" workflow
3. Click "Run workflow"
4. Choose environment (staging/production)
5. Click "Run workflow"

## Customization

### SonarCloud Integration
Update the SonarCloud configuration in `ci-cd.yml`:
```yaml
dotnet sonarscanner begin /k:"your-org_your-repo" /o:"your-org"
```

### Deployment Commands
Replace the placeholder deployment commands in `deploy.yml` with your actual deployment scripts (Azure, AWS, Docker, etc.).

### Environment Variables
Modify the `env` section in workflows to match your project configuration.

## Best Practices

1. **Branch Protection**: Enable branch protection rules for `main` and `develop`
2. **Required Checks**: Require status checks to pass before merging
3. **Environment Protection**: Use environment protection rules for production
4. **Secrets Management**: Store sensitive information in GitHub Secrets
5. **Artifact Retention**: Configure appropriate artifact retention periods

## Troubleshooting

### Common Issues
- **Build Failures**: Check .NET version compatibility
- **Test Failures**: Ensure all tests pass locally
- **Deployment Issues**: Verify environment secrets and permissions
- **SonarCloud Errors**: Check SONAR_TOKEN secret and project configuration

### Logs
All workflow logs are available in the Actions tab of your GitHub repository.