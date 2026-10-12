program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: Boolean;
  v6: Boolean;
  v8: Boolean;
  v7: Boolean;
  v10: Boolean;
  v9: Boolean;
  v12: Boolean;
  v11: Boolean;
  v14: Boolean;
  v13: Boolean;
  v16: Boolean;
  v15: Boolean;
  v18: Boolean;
  v17: Boolean;
  v20: Boolean;
  v19: Boolean;
begin
  v0 := 'a';
  v1 := 'b';
  v2 := #195#169;
  v3 := #195#169'x';
  v4 := '';
  v5 := v0 < v0;
  if v5 then begin
      Result := 1;
  end else begin
      v6 := v0 < v1;
      if v6 then begin
          v7 := v1 < v2;
          v8 := v7;
      end else begin
          v8 := False;
      end;
      if v8 then begin
          v9 := v2 < v3;
          v10 := v9;
      end else begin
          v10 := False;
      end;
      if v10 then begin
          v11 := v4 < v0;
          v12 := v11;
      end else begin
          v12 := False;
      end;
      if v12 then begin
          v13 := v0 <= v0;
          v14 := v13;
      end else begin
          v14 := False;
      end;
      if v14 then begin
          v15 := v0 >= v0;
          v16 := v15;
      end else begin
          v16 := False;
      end;
      if v16 then begin
          v17 := v3 > v2;
          v18 := v17;
      end else begin
          v18 := False;
      end;
      if v18 then begin
          v19 := v1 >= v0;
          v20 := v19;
      end else begin
          v20 := False;
      end;
      if v20 then begin
          Result := 0;
      end else begin
          Result := 1;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
