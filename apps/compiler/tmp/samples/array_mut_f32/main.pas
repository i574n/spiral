program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TMut0 = class;
  TBoxArray0 = class;
  TMut0 = class(TSpiralRc) l0: Single; l1: AnsiString; end;
  TBoxArray0 = class(TSpiralRc) items: array of TMut0; procedure DropFields; override; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function MutCreate0(a0: Single; a1: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0; Result.l1 := a1;
end;
procedure TBoxArray0.DropFields;
var i: Int64;
begin
  for i := 0 to High(items) do begin SpiralRelease(items[i]); end;
end;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: AnsiString;
  v2: TMut0;
  v3: TBoxArray0;
  tmp4: TBoxArray0;
  v4: TMut0;
  v5: Single;
  v6: AnsiString;
  v7: Single;
  v8: AnsiString;
  v9: Boolean;
  v11: Boolean;
  v10: Boolean;
begin
  v0 := 1.5;
  v1 := 'no';
  v2 := MutCreate0(v0, v1);
  tmp4 := TBoxArray0.Create;
  SetLength(tmp4.items, 1);
  v3 := tmp4;
  SpiralRetain(v2); SpiralRelease(v3.items[0]); v3.items[0] := v2;
  SpiralRelease(v2);
  v4 := v3.items[0];
  SpiralRetain(v4);
  SpiralRelease(v3);
  v5 := 2.5;
  v6 := 'hi';
  v4.l0 := v5;
  v4.l1 := v6;
  v7 := v4.l0;
  v8 := v4.l1;
  SpiralRelease(v4);
  v9 := v7 = 2.5;
  if v9 then begin
      v10 := v8 = 'hi';
      v11 := v10;
  end else begin
      v11 := False;
  end;
  if v11 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
