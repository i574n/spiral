program SpiralGenerated;
{$mode objfpc}{$H+}

function spiral_libc_strlen(value: PAnsiChar): SizeUInt; cdecl; external 'c' name 'strlen';

function spiral_abi_libc_strlen(const value: AnsiString): LongInt; inline;
var
  rawLength: SizeUInt;
begin
  if Pos(#0, value) <> 0 then Halt(86);
  rawLength := spiral_libc_strlen(PAnsiChar(value));
  if rawLength > SizeUInt(High(LongInt)) then Halt(87);
  Result := LongInt(rawLength);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
begin
  v0 := 'spiral';
  v1 := spiral_abi_libc_strlen(v0);
  Exit(v1);
end;

begin
  Halt(SpiralMain);
end.
