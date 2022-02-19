# Deploying to AWS Lambda
Full instructions can be found here https://github.com/awslabs/aws-lambda-rust-runtime.

## Prerequisites
1. Rust toolchain for target `x86_64-unknown-linux-gnu`. This is the appropriate target for Amazon 
   Linux 2. This target can be installed with rustup.
   ```
   $ rustup target add x86_64-unknown-linux-gnu
   ```

2. Docker. Not strictly required, but the following steps require Docker for simplicity.

3. The `cross` tool. See https://github.com/cross-rs/cross. Not strictly required, but useful as it 
   runs Cargo in a docker container with with the right dependencies for the build target. Install 
   using Cargo.
   ```
   $ cargo install cross
   ```

## Building the Lambda asset
The following steps are implemented in the script `build.ps1`

1. Build for application for Amazon Linux 2 (substitute `cross` with `cargo` if you need).
   ```
   $ cross build --release --target x86_64-unknown-linux-gnu
   ```
   `Cargo.toml` is configured to call the binary `bootstrap`. This name is required by AWS Lambda

2. Place the built binary into a zip archive.

## Deploying to Lambda
The CDK application in the `cdk` directory deploys the Lambda function to AWS, presuming the Lambda
asset is located at `lambda.zip`. See `cdk/README.md`.

# Hints
You can run the lambda function using the AWS CLI. Use the following to create an alias that runs 
the AWS CLI in Docker:
```
Function AWSCLI {docker run --rm -it -v "$env:userprofile\.aws:/root/.aws" -v "${pwd}:/aws" -e "AWS_ACCESS_KEY_ID=$env:AWS_ACCESS_KEY_ID" -e "AWS_SECRET_ACCESS_KEY=$env:AWS_SECRET_ACCESS_KEY" -e "AWS_DEFAULT_REGION=$env:AWS_DEFAULT_REGION" amazon/aws-cli $args}
Set-Alias -Name aws -Value AWSCLI
```

# TODO
- Update https://docs.aws.amazon.com/sdk-for-rust/latest/dg/lambda.html and submit pull request.
