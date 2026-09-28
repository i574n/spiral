program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

function SpiralStringIndex(const value: AnsiString; index: LongInt): Byte;
begin
  if (index < 0) or (index >= Length(value)) then raise ERangeError.Create('Spiral string index out of bounds');
  Result := Ord(value[index + 1]);
end;

function SpiralStringSlice(const value: AnsiString; fromIndex, toIndex: LongInt): AnsiString;
begin
  if (fromIndex < 0) or (fromIndex > Length(value)) or (toIndex < fromIndex - 1) or (toIndex >= Length(value)) then raise ERangeError.Create('Spiral string slice out of bounds');
  if (toIndex >= fromIndex) and ((((Ord(value[fromIndex + 1])) and $C0) = $80) or ((toIndex + 1 < Length(value)) and (((Ord(value[toIndex + 2])) and $C0) = $80))) then raise ERangeError.Create('Spiral string slice must preserve UTF-8 codepoint boundaries');
  if toIndex < fromIndex then Result := ''
  else Result := Copy(value, fromIndex + 1, toIndex - fromIndex + 1);
end;

function SpiralStringConcat(const left, right: AnsiString): AnsiString;
begin
  Result := left + right;
end;

function empty_middle0(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := SpiralStringSlice(v0, 2, 1);
  Exit(v1);
end;

function empty_end1(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := SpiralStringSlice(v0, 5, 4);
  Exit(v1);
end;

function empty_source2(v0: AnsiString): AnsiString;
var
  v1: LongInt;
  v2: AnsiString;
begin
  v1 := (0 - 1);
  v2 := SpiralStringSlice(v0, 0, v1);
  Exit(v2);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
  v7: AnsiString;
  v8: LongInt;
  v9: Boolean;
  v10: LongInt;
  v11: Boolean;
  v12: LongInt;
  v13: Boolean;
  v14: LongInt;
  v15: Boolean;
  v16: Byte;
  v17: Boolean;
  v18: Byte;
  v19: Boolean;
begin
  v0 := 'alpha';
  v1 := empty_middle0(v0);
  v2 := empty_end1(v0);
  v3 := '';
  v4 := empty_source2(v3);
  v5 := SpiralStringConcat(v1, v2);
  v6 := SpiralStringConcat(v4, 'ok');
  v7 := SpiralStringConcat(v5, v6);
  v8 := Length(v1);
  v9 := (v8 = 0);
  if v9 then begin
    v10 := Length(v2);
    v11 := (v10 = 0);
    if v11 then begin
      v12 := Length(v4);
      v13 := (v12 = 0);
      if v13 then begin
        v14 := Length(v7);
        v15 := (v14 = 2);
        if v15 then begin
          v16 := SpiralStringIndex(v7, 0);
          v17 := (v16 = 111);
          if v17 then begin
            v18 := SpiralStringIndex(v7, 1);
            v19 := (v18 = 107);
            if v19 then begin
              Exit(0);
            end else begin
              Exit(1);
            end;
          end else begin
            Exit(2);
          end;
        end else begin
          Exit(3);
        end;
      end else begin
        Exit(4);
      end;
    end else begin
      Exit(5);
    end;
  end else begin
    Exit(6);
  end;
end;

begin
  Halt(SpiralMain);
end.
