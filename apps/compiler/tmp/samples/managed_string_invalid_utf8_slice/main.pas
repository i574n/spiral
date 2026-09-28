program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

function SpiralStringSlice(const value: AnsiString; fromIndex, toIndex: LongInt): AnsiString;
begin
  if (fromIndex < 0) or (fromIndex > Length(value)) or (toIndex < fromIndex - 1) or (toIndex >= Length(value)) then raise ERangeError.Create('Spiral string slice out of bounds');
  if (toIndex >= fromIndex) and ((((Ord(value[fromIndex + 1])) and $C0) = $80) or ((toIndex + 1 < Length(value)) and (((Ord(value[toIndex + 2])) and $C0) = $80))) then raise ERangeError.Create('Spiral string slice must preserve UTF-8 codepoint boundaries');
  if toIndex < fromIndex then Result := ''
  else Result := Copy(value, fromIndex + 1, toIndex - fromIndex + 1);
end;

function invalid_middle0(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := SpiralStringSlice(v0, 1, 1);
  Exit(v1);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: LongInt;
begin
  v0 := 'é';
  v1 := invalid_middle0(v0);
  v2 := Length(v1);
  Exit(v2);
end;

begin
  Halt(SpiralMain);
end.
