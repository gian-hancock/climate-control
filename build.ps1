Write-Output "Running ``cross build --release --target x86_64-unknown-linux-gnu``"
cross build --release --target x86_64-unknown-linux-gnu | Write-Output

$binaryPath = "$PSScriptRoot/target/x86_64-unknown-linux-gnu/release/bootstrap"
$archivePath = "$PSScriptRoot/target/x86_64-unknown-linux-gnu/release/bootstrap.zip"
Write-Output "Adding ``$binaryPath`` to archive ``$archivePath``"
Compress-Archive -Force -Path $binaryPath -DestinationPath $archivePath -CompressionLevel "Fastest"
